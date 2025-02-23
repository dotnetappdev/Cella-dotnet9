using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Framework.Settings.Localization
{
   public  class LocalizationSettings
    {     /// <summary>
          /// A value indicating whether to load all LocaleStringResource records on application startup
          /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; }

        /// <summary>
        /// A value indicating whether to load all LocalizedProperty records on application startup
        /// </summary>
        public bool LoadAllLocalizedPropertiesOnStartup { get; set; }

        /// <summary>
        /// A value indicating whether to load all search engine friendly names (slugs) on application startup
        /// </summary>
        public bool LoadAllUrlRecordsOnStartup { get; set; }
        /// <summary>
        /// A value indicating whether we should detect the current language by a customer region (browser settings)
        /// </summary>
        public bool AutomaticallyDetectLanguage { get; set; }

    }
}
