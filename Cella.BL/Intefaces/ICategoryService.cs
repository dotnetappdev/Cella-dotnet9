using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Models.ViewModels;

namespace Cella.BL.Intefaces
{
    public partial interface ICategoryService
    {
        public CategoriesViewModel GetAllCategoriesViewModel(Guid userId, Guid storeId);



    }
}
