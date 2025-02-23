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
using Microsoft.EntityFrameworkCore;
namespace Cella.BL.Services.Database
{
    public class CellaDBServices
    {
        private readonly CellaDBContext _context;
        private readonly IToastNotification _toast;

        public CellaDBServices(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast)
        {
            _context = context;
            _toast = toast;
        }
        public Task<List<Categories>> GetAllCatgoriesViewModelAsyncByStoreId(Guid StoreId,Guid TennantId)
        {
            return _context.Categories.Where(w => w.StoreId == StoreId && w.TennantId == TennantId).ToListAsync();

        }
    }
}
