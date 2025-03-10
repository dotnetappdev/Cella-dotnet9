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
       public void AddProduct(Stock product);

        public void UpdateProduct(Stock product);

       public  void DeleteProductAsync(Stock product);

    }
}
