using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Application.Interfaces
{
    public  interface IProductInterface
    {
       public void AddProduct(Product product);

        public void UpdateProduct(Product product);

       public  void DeleteProductAsync(Product product);

    }
}
