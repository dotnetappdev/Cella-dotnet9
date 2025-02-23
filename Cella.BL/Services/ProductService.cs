using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.BL.Intefaces;
using Cella.Models;
using Cella.Models.ViewModels;
using Cella.Domain;

namespace Cella.BL.Services
{
   public class ProductService:IProductService
    {
        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        public ProductService(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast)

        {
            _context = context;
            _toast = toast;


        }
        public ProductListingsViewModel GetProductsByCategory(Guid userId, Guid storedId,int id)
        {
            ProductListingsViewModel vm = new ProductListingsViewModel();
            vm.Products = _context.Product.Where(w => w.UserId == userId && w.StoreId== storedId && w.isDeleted==false && w.isActive==true).ToList();
            vm.Categories = _context.Categories.Where(w => w.UserId == userId && w.StoreId == storedId && w.isDeleted == false && w.isActive == true).ToList();

            return vm;

        }
         
    }
}
