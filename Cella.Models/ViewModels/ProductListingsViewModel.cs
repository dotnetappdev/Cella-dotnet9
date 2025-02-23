using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models.ViewModels
{
    public class ProductListingsViewModel
    {
        public List<Categories> Categories { get; set; }
        public List<Product> Products { get; set; }

        public string? Price { get; set; }
    }
}
