using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.BL.Interfaces
{
    public interface IPriceFormatter
    {
         Task<string> FormatPriceAsync(decimal price, bool showCurrency, Currency targetCurrency, int languageId, bool priceIncludesTax, bool showTax);


         string GetCurrencyString(decimal amount, bool showCurrency, Currency targetCurrency);
    }


}
