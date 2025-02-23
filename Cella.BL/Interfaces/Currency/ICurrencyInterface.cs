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
namespace Cella.BL.Interfaces.Currencies
{
   public interface ICurrencyInterface
    {
        Task<Currency> GetCurrencyByIdAsync(int currencyId);



    }
}
