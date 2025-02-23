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
using Cella.Domain;
using Cella.Models.ViewModels;

namespace Cella.BL.Services
{
   public class CategoryService : ICategoryService
    {

        private CellaDBContext _context;
        private readonly IToastNotification _toast;
        public CategoryService(CellaDBContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IToastNotification toast) 

        {
            _context = context;
            _toast = toast;
         

        }
    
        public CategoriesViewModel GetAllCategoriesViewModel(Guid userId, Guid storeId)
        {
            CategoriesViewModel categoriesViewModel = new CategoriesViewModel();
            categoriesViewModel.Categories= _context.Categories.Where(w => w.isActive == true && w.isDeleted == false && w.UserId ==userId && w.StoreId==storeId).ToList();
            return categoriesViewModel;

        }


        public List<Categories> GetAllCategoriesByStoreId(Guid storeId)
        {
            return _context.Categories.Where(w => w.StoreId==storeId && w.isActive == true && w.isDeleted == false).ToList();

        }

       
    }
}
