using Cella.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Cella.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Cella.Infrastructure.ViewComponents.Currency
{
    [ViewComponent(Name = "CurrencySelector")]
    public class CurrencySelectorViewComponent : CellaViewComponentBase
    {
        private CellaDBContext _context;
        private IConfiguration _config;
        public CurrencySelectorViewComponent(CellaDBContext cellaDBContext, IConfiguration config)
        {
            _context = cellaDBContext;
            _config = config;
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        { 
        
            CurrencySelectorViewModel vm = new CurrencySelectorViewModel();
            var record = _context.Appsettings.Where(w => w.Key == Constants.FrontEndDefaultLanguageId).FirstOrDefault();
            vm.AvailableCurrencies = await _context.Currencies.ToListAsync();
        
            Int32.TryParse(record.Value,  out int currentCurrencyId);
           // NumberFormatInfo numberInfo = CultureInfo.CreateSpecificCulture().NumberFormat;

           // Response.Cookies.Append(
           //    CookieRequestCultureProvider.DefaultCookieName,
           //    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
           //    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
           //);

            vm.CurrentCurrencyId = currentCurrencyId;
            if (vm.AvailableCurrencies.Count == 1)
                return View("");

            return View(vm);
        }
    }
}
