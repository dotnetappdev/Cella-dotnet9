﻿
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.BL.Interfaces;
using Cella.Domain;
using Cella.Infrastructure;
using Cella.Models;
using Cella.Models.ViewModels;
 
namespace Cella.BL.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IConfigurationRoot _configurationRoot;
        private string _currentThemeName;
        private CellaDBContext _context;
        public ThemeService(IConfiguration configuration, CellaDBContext context)
        {
            _configurationRoot = (IConfigurationRoot)configuration;
            _currentThemeName = configuration[Constants.ThemeConfigKey];
            _context = context;

        }
        public async Task<IList<ThemeListItem>> GetInstalledThemes()
        {

            IList<ThemeListItem> themes = new List<ThemeListItem>
            {
                new ThemeListItem
                {
                    Name = "Generic",
                    DisplayName = "Generic",
                    IsCurrent = "Generic" == _currentThemeName,
                    ThumbnailUrl = "/themes/generic-theme.png"
                }
            };

            var themeRootFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes"));
            var themeFolders = themeRootFolder.GetDirectories();

            foreach (var themeFolder in themeFolders)
            {
                var themeJsonPath = Path.Combine(themeFolder.FullName, "theme.json");
                if (!File.Exists(themeJsonPath))
                {
                    throw new ApplicationException($"Cannot found theme.json for theme {themeFolder.Name}");
                }


                var manifestStr = await File.ReadAllTextAsync(themeJsonPath);
                ThemeManifest themeManifest;
                themeManifest = JsonConvert.DeserializeObject<ThemeManifest>(manifestStr);
                var theme = new ThemeListItem
                {
                    Name = themeManifest.Name,
                    DisplayName = themeManifest.DisplayName,
                    IsCurrent = themeManifest.Name == _currentThemeName,
                    ThumbnailUrl = $"/themes/{themeManifest.Name}/{themeManifest.Name}.png"
                };

                themes.Add(theme);
            }

            return themes;
        }


        public string PackTheme(string themeName)
        {
            var themeFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes", themeName));
            var themeFolderWWWroot = new DirectoryInfo(Path.Combine(GlobalConfiguration.WebRootPath, "themes", themeName));

            var tempFolderName = Guid.NewGuid().ToString();
            var tempDir = Directory.CreateDirectory(Path.Combine(GlobalConfiguration.ContentRootPath, "Temps", tempFolderName));
            DirectoryCopy(themeFolder.FullName, Path.Combine(tempDir.FullName, "Themes", themeName), true);
            DirectoryCopy(themeFolderWWWroot.FullName, Path.Combine(tempDir.FullName, "wwwroot", "themes", themeName), true);

            var destinationArchiveFileName = Path.Combine(GlobalConfiguration.ContentRootPath, "Temps", $"{tempFolderName}.zip");
            ZipFile.CreateFromDirectory(tempDir.FullName, destinationArchiveFileName);
            Directory.Delete(tempDir.FullName, true);
            return destinationArchiveFileName;
        }

        public async Task Install(Stream stream, string themeName)
        {
            var zipFilePath = Path.Combine(GlobalConfiguration.ContentRootPath, "Temps", $"{themeName}.zip");
            using (var output = new FileStream(zipFilePath, FileMode.Create))
            {
                await stream.CopyToAsync(output);
            }

            var extractPath = Path.Combine(GlobalConfiguration.ContentRootPath, "Temps", themeName);
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);

            var themeFolder = new DirectoryInfo(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes", themeName));
            var themeFolderWWWroot = new DirectoryInfo(Path.Combine(GlobalConfiguration.WebRootPath, "themes", themeName));
            DirectoryCopy(Path.Combine(extractPath, "Themes", themeName), themeFolder.FullName, true);
            DirectoryCopy(Path.Combine(extractPath, "wwwroot", "themes", themeName), themeFolderWWWroot.FullName, true);

            Directory.Delete(extractPath, true);
            File.Delete(zipFilePath);
        }

        public void Delete(string themeName)
        {
            Directory.Delete(Path.Combine(GlobalConfiguration.ContentRootPath, "Themes", themeName), true);
            Directory.Delete(Path.Combine(GlobalConfiguration.WebRootPath, "themes", themeName), true);
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo sourceDirectory = new DirectoryInfo(sourceDirName);
            if (!sourceDirectory.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = sourceDirectory.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                DirectoryInfo[] sourceSubDirectories = sourceDirectory.GetDirectories();
                foreach (DirectoryInfo subdir in sourceSubDirectories)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


        public async Task SetCurrentTheme(string themeName)
        {
            SystemSetup themeSetting = _context.SystemSetup.First();

            themeSetting.Theme = themeName;

            await _context.SaveChangesAsync();
        }
        
        }
        
    


}
