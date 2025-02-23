using Cella.Infrastructure.Framework.Localization;
using Cella.Infrastructure.Interface.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Cella.Domain;

namespace Cella.Infrastructure.Framework
{
    public abstract class CellaRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
         private Localizer _localizer;
        

        /// <summary>
        /// Get a localized resources
        /// </summary>
        public Localizer T
        {
            get
            {
                var serviceProviderContext = Context.RequestServices.GetRequiredService<CellaDBContext>();
                Int32.TryParse(serviceProviderContext.Appsettings.Where(w => w.Key == Constants.FrontEndDefaultLanguageId).FirstOrDefault().Value, out int defaultLangId);
                var serviceProvider = Context.RequestServices.GetRequiredService<ILocalizationService>();
                

                if (_localizer == null)
                {
                    _localizer = (format, args) =>
                    {  //we want to set the default langauge id here so whatever the user sets will always be shown.
                        var resFormat = serviceProvider.GetResourceAsync(format, defaultLangId).Result;
                        if (string.IsNullOrEmpty(resFormat))
                        {
                            return new LocalizedString(format);
                        }
                        return new LocalizedString((args == null || args.Length == 0)
                            ? resFormat
                            : string.Format(resFormat, args));
                    };
                }
                return _localizer;
            }
        }

    }


    /// <summary>
    /// Web view page
    /// </summary>
    public abstract class CellaRazorPage : CellaRazorPage<dynamic>
    {
    }
}
