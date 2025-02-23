using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain
{
    public class Constants
    {
        public static string ApiUrl { get; internal set; }
        public static string Authenticate = "/Authenticate";
        public const string ThemeConfigKey = "theme";
        public const string Theme = "Default";
        public const string ApiKeyUrl = "https://localhost:44347";
        public const string FrontEndDefaultLanguageId = "FrontEnd.CultureId";
        public const string ThemFolderNameConfigKey = "ThemesFolderName";
        public const string DomainName = "https://localhost:44347";
        public const string GlobalCurrencyCulture = "Global.CurrencyCulture";

        public const string GetAllSockEndPoint = "";
    }
}
