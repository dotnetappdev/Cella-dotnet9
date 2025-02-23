using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Models;
using Cella.Models.ViewModels;

namespace Cella.BL.Intefaces
{
   public  interface IProductService
    {
        ProductListingsViewModel GetProductsByCategory(Guid userId, Guid storedId, int id);
    

    }
}
