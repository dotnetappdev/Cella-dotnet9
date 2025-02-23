using Cella.Domain;
using Cella.Domain.Localization;
using Cella.Infrastructure.Framework.Localization;
using Cella.Infrastructure.Framework.Settings.Localization;
using Cella.Infrastructure.Installation.Localization;
using Cella.Infrastructure.Interface.Localization;
using System;
using Microsoft.EntityFrameworkCore;


using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.FileProviders.Internal;
using Microsoft.Extensions.FileProviders;
using Cella.Models;

namespace Cella.Infrastructure.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly LocalizationSettings _localizationSettings;
        private readonly ILocalizationService _localizationService;
        private readonly List<LocaleStringResource> _lsrRepository;
        private CellaDBContext _context;
        public LocalizationService(CellaDBContext cellaDBContext)
        {

            _context = cellaDBContext;

        }
        /// <summary>
        /// Determines if the string is a valid Universal Naming Convention (UNC)
        /// for a server and share path.
        /// </summary>
        /// <param name="path">The path to be tested.</param>
        /// <returns><see langword="true"/> if the path is a valid UNC path; 
        /// otherwise, <see langword="false"/>.</returns>
        protected static bool IsUncPath(string path)
        {
            return Uri.TryCreate(path, UriKind.Absolute, out var uri) && uri.IsUnc;
        }
        /// <summary>
        /// Combines an array of strings into a path
        /// </summary>
        /// <param name="paths">An array of parts of the path</param>
        /// <returns>The combined paths</returns>
        public virtual string Combine(params string[] paths)
        {
            var path = Path.Combine(paths.SelectMany(p => IsUncPath(p) ? new[] { p } : p.Split('\\', '/')).ToArray());

            if (Environment.OSVersion.Platform == PlatformID.Unix && !IsUncPath(path))
                //add leading slash to correctly form path in the UNIX system
                path = "/" + path;

            return path;
        }

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public virtual string MapPath(string path)
        {
            path = path.Replace("~/", string.Empty).TrimStart('/');

            //if virtual path has slash on the end, it should be after transform the virtual path to physical path too
            var pathEnd = path.EndsWith('/') ? Path.DirectorySeparatorChar.ToString() : string.Empty;
            var provider = new PhysicalFileProvider(path);

            return Combine(provider.Root ?? string.Empty, path) + pathEnd;
        }
        protected string WebRootPath { get; }

        public virtual IEnumerable<string> EnumerateFiles(string directoryPath, string searchPattern,
       bool topDirectoryOnly = true)
        {
            return Directory.EnumerateFiles(directoryPath, searchPattern,
                topDirectoryOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);
        }
        public async Task InstallLanguagesAsync()
        {
            var defaultCulture = new CultureInfo(CellaInstallationDefaults.DefaultLanguageCulture);
            var defaultLanguage = new Language
            {
                Name = defaultCulture.TwoLetterISOLanguageName.ToUpper(),
                LanguageCulture = defaultCulture.Name,
                UniqueSeoCode = defaultCulture.TwoLetterISOLanguageName,
                FlagImageFileName = $"{defaultCulture.Name.ToLower()[^2..]}.png",
                Rtl = defaultCulture.TextInfo.IsRightToLeft,
                Published = true,
                DisplayOrder = 1
            };
            //Install locale resources for default culture
            var directoryPath = MapPath(CellaInstallationDefaults.LocalizationResourcesPath);
            var pattern = $"*.{CellaInstallationDefaults.LocalizationResourcesFileExtension}";
            foreach (var filePath in EnumerateFiles(directoryPath, pattern))
            {
                using var streamReader = new StreamReader(filePath);
                await ImportResourcesFromXmlAsync(defaultLanguage, streamReader);
            }

        }
        private static Dictionary<string, KeyValuePair<int, string>> ResourceValuesToDictionary(IEnumerable<LocaleStringResource> locales)
        {
            //format: <name, <id, value>>
            var dictionary = new Dictionary<string, KeyValuePair<int, string>>();
            foreach (var locale in locales)
            {
                var resourceName = locale.ResourceName.ToLowerInvariant();
                if (!dictionary.ContainsKey(resourceName))
                    dictionary.Add(resourceName, new KeyValuePair<int, string>(locale.Id, locale.ResourceValue));
            }

            return dictionary;
        }
        protected virtual HashSet<(string name, string value)> LoadLocaleResourcesFromStream(StreamReader xmlStreamReader, string language)
        {
            var result = new HashSet<(string name, string value)>();

            using (var xmlReader = XmlReader.Create(xmlStreamReader))
                while (xmlReader.ReadToFollowing("Language"))
                {
                    if (xmlReader.NodeType != XmlNodeType.Element)
                        continue;

                    using var languageReader = xmlReader.ReadSubtree();
                    while (languageReader.ReadToFollowing("LocaleResource"))
                        if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.GetAttribute("Name") is string name)
                        {
                            using var lrReader = languageReader.ReadSubtree();
                            if (lrReader.ReadToFollowing("Value") && lrReader.NodeType == XmlNodeType.Element)
                                result.Add((name.ToLowerInvariant(), lrReader.ReadString()));
                        }

                    break;
                }

            return result;
        }


        /// <summary>
        /// Import language resources from XML file
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="xmlStreamReader">Stream reader of XML file</param>
        /// <param name="updateExistingResources">A value indicating whether to update existing resources</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task ImportResourcesFromXmlAsync(Language language, StreamReader xmlStreamReader, bool updateExistingResources = true)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            if (xmlStreamReader.EndOfStream)
                return;

            var lsNamesList = new Dictionary<string, LocaleStringResource>();

            foreach (var localeStringResource in _lsrRepository.Where(lsr => lsr.LanguageId == language.Id)
                .OrderBy(lsr => lsr.Id))
                lsNamesList[localeStringResource.ResourceName.ToLowerInvariant()] = localeStringResource;

            var lrsToUpdateList = new List<LocaleStringResource>();
            var lrsToInsertList = new Dictionary<string, LocaleStringResource>();

            foreach (var (name, value) in LoadLocaleResourcesFromStream(xmlStreamReader, language.Name))
            {
                if (lsNamesList.ContainsKey(name))
                {
                    if (!updateExistingResources)
                        continue;

                    var lsr = lsNamesList[name];
                    lsr.ResourceValue = value;
                    lrsToUpdateList.Add(lsr);
                }
                else
                {
                    var lsr = new LocaleStringResource { LanguageId = language.Id, ResourceName = name, ResourceValue = value };
                    lrsToInsertList[name] = lsr;
                }
            }
            //   await _context.LAN
            //    await _lsrRepository.UpdateAsync(lrsToUpdateList, false);
            //     await _lsrRepository.InsertAsync(lrsToInsertList.Values.ToList(), false);

            //clear cache
            //      await _staticCacheManager.RemoveByPrefixAsync(NopEntityCacheDefaults<LocaleStringResource>.Prefix);
        }
        public virtual async Task<string> GetResourceAsync(string resourceKey, int languageId,
           bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {

            if (resourceKey == null)
                resourceKey = string.Empty;
            resourceKey = resourceKey.Trim().ToLowerInvariant();
            var result = await _context.LocaleStringResource.Where(w => w.ResourceName == resourceKey && w.LanguageId == languageId && w.isDeleted == false && w.isActive == true).FirstOrDefaultAsync();
            var resultString = string.Empty;
            if (result != null)
                resultString = result.ResourceValue;
            else
                resultString = resourceKey;

            return resultString;
        }
        public virtual async Task<string> GetResourceAsync(string resourceKey, int langugeID)
        {
            var result = await _context.LocaleStringResource.Where(w => w.ResourceName == resourceKey && w.LanguageId == langugeID && w.isDeleted == false && w.isActive == true).FirstOrDefaultAsync();
            var resultString = string.Empty;
            if (result != null)
                resultString = result.ResourceValue;
            else
                resultString = resourceKey;
            return resultString;
        }

        Task ILocalizationService.InstallLanguagesAsync((string languagePackDownloadLink, int languagePackProgress) languagePackInfo, CultureInfo cultureInfo, RegionInfo regionInfo)
        {
            throw new NotImplementedException();
        }
    }
}


