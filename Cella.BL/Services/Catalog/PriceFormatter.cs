using Cella.BL.Interfaces;
using Cella.Domain;
using Cella.Infrastructure.Interface.Localization;
using Cella.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.BL.Services.Catalog
{
    public class PriceFormatter : IPriceFormatter
    {
        private readonly ILocalizationService _localizationService;
        private readonly CellaDBContext _context;
        
        public PriceFormatter(CellaDBContext context ,ILocalizationService localizationService)
        {
            _context = context;
            _localizationService = localizationService;
        }

       public async Task<string> FormatPriceAsync(decimal price, bool showCurrency, Currency targetCurrency, int languageId, bool priceIncludesTax, bool showTax)
        {

            var currencyString =  GetCurrencyString(price, showCurrency, targetCurrency);

            string formatStr;
            if (priceIncludesTax)
            {
                formatStr =await _localizationService.GetResourceAsync("Products.InclTaxSuffix", languageId, false);
                if (string.IsNullOrEmpty(formatStr))
                    formatStr = "{0} incl tax";
            }
            else
            {
                formatStr = await _localizationService.GetResourceAsync("Products.ExclTaxSuffix", languageId, false);           
                if (string.IsNullOrEmpty(formatStr))
                    formatStr = "{0} excl tax";
            }
            var test= string.Format(formatStr, currencyString); 
            return string.Format(formatStr, currencyString);
        }

        public  string GetCurrencyString(decimal amount, bool showCurrency, Currency targetCurrency)
        {

            if (targetCurrency == null)
                throw new ArgumentNullException(nameof(targetCurrency));

            string result;
            if (!string.IsNullOrEmpty(targetCurrency.CustomFormatting))
                //custom formatting specified by a store owner
                result = amount.ToString(targetCurrency.CustomFormatting);
            else
            {
                if (!string.IsNullOrEmpty(targetCurrency.DisplayLocale))
                    //default behavior
                    result = amount.ToString("C", new CultureInfo(targetCurrency.DisplayLocale));
                else
                {
                    //not possible because "DisplayLocale" should be always specified
                    //but anyway let's just handle this behavior
                    result = $"{amount:N} ({targetCurrency.CurrencyCode})";
                    return result;
                }
            }
            //display currency code?
            if (showCurrency)
                result = $"{result} ({targetCurrency.CurrencyCode})";
            return result;
        }

         
    }
    }
