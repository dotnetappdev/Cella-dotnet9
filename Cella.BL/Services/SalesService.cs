using Cella.BL.Intefaces;
using Cella.Domain;
using Cella.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.BL.Services
{
    public class SalesService : ISalesInterface
    {
        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        public SalesService(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast)

        {
            _context = context;
            _toast = toast;


        }

        public void GetAllSalesOrders(Guid UserId,Guid StoreId)
        {


            var salesOrders = _context.SalesOrders.Where(w => w.UserId == UserId);

        }
    }
}
