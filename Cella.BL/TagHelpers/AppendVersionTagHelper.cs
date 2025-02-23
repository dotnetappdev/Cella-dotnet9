using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using Cella.Domain;

namespace Cella.BL.TagHelpers
{
    [HtmlTargetElement(Attributes = AppendVersionAttributeName)]
    public class AppendVersionTagHelper : TagHelper
    {
        private const string AppendVersionAttributeName = "cella-append-version";
        private readonly IConfiguration _config;

        public AppendVersionTagHelper(IConfiguration config)
        {
            _config = config;
        }

        [HtmlAttributeName(AppendVersionAttributeName)]
        public bool AppendVersion { get; set; }

        public override int Order => int.MinValue;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll(AppendVersionAttributeName);

            if (!AppendVersion)
            {


                if (output.Attributes.ContainsName("href"))
                {
                    var href = output.Attributes["href"].Value.ToString();
                    output.Attributes.SetAttribute("href", AppendVersionToUrl(href));
                }
            }

            if (!AppendVersion)
            {
                if (output.Attributes.ContainsName("src"))
                {
                    var src = output.Attributes["src"].Value.ToString();

                    output.Attributes.SetAttribute("src", AppendVersionToUrl(src));
                }
            }

            if (output.Attributes.ContainsName("href"))
            {
                var href = output.Attributes["href"].Value.ToString();
                output.Attributes.SetAttribute("href", AppendThemeNameToUrl(href));
            }
            if (output.Attributes.ContainsName("src"))
            {
                var src = output.Attributes["src"].Value.ToString();
                var replace = AppendThemeNameToUrl(src);
                output.Attributes.SetAttribute("src", replace);
            }
            if (output.Attributes.ContainsName("xlink:href"))
            {
                var src = output.Attributes["xlink:href"].Value.ToString();
                var replace = AppDomainNameToImage(src);
                output.Attributes.SetAttribute("xlink:href", replace);
            }
        }

        private string AppDomainNameToImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            var theme = Constants.DomainName + @"/" + _config[Constants.ThemFolderNameConfigKey] + @"/" + _config["Theme"];
        
            url = url.Replace("_DomainName", theme);

            return url;
        }
        private string AppendThemeNameToUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            var theme = _config[Constants.ThemFolderNameConfigKey] + @"/"+ _config["Theme"];
        
            url = url.Replace("_content", theme);

            return url;
        }
        private string AppendVersionToUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            var version = _config["Global.AssetVersion"];

            return url.Contains("?") ? $"{url}&v={version}" : $"{url}?v={version}";
        }
    }
}