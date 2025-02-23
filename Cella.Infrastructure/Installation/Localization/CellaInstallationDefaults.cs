using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Installation.Localization
{
  public  class CellaInstallationDefaults
    { /// <summary>
      /// Gets a request path to the install URL
      /// </summary>
        public static string InstallPath => "install";

        /// <summary>
        /// Gets a path to the localization resources file
        /// </summary>
        public static string LocalizationResourcesPath => "~/Localization/";

        /// <summary>
        /// Gets a localization resources file extension
        /// </summary>
        public static string LocalizationResourcesFileExtension => "nopres.xml";

        /// <summary>
        /// Gets a path to the installation sample images
        /// </summary>
        public static string SampleImagesPath => "images\\samples\\";

        /// <summary>
        /// Gets a name of the default pattern locale
        /// </summary>
        public static string DefaultLocalePattern => "en";

        /// <summary>
        /// Gets default CultureInfo 
        /// </summary>
        public static string DefaultLanguageCulture => "en-GB"; 

    }
}
