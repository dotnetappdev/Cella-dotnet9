using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Domain;
using Cella.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Microsoft.EntityFrameworkCore;
namespace Cella.BL.Services.Currencies
{
   public  class CurrencyService
    {
        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        public CurrencyService(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast)

        {
            _context = context;
            _toast = toast;


        }
        public async Task<Currency> GetCurrencyByIdAsync(int currencyId)
        {
            var appSetting =await  _context.Appsettings.Where(w => w.Key == Constants.GlobalCurrencyCulture).FirstOrDefaultAsync();
            Int32.TryParse(appSetting.Value, out int currencyResult);

            Currency currency = await _context.Currencies.Where(w => w.Id == currencyResult).FirstOrDefaultAsync();
            return currency;


        }
    }
}
