using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Interface.Localization
{
    public partial interface ILocalizationService
    {
        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains a string representing the requested resource string.
        /// </returns>
        Task<string> GetResourceAsync(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);

        Task<string> GetResourceAsync(string resourceKey, int langugeID);
        Task InstallLanguagesAsync((string languagePackDownloadLink, int languagePackProgress) languagePackInfo, CultureInfo cultureInfo, RegionInfo regionInfo);
        Task InstallLanguagesAsync();
    }
}
