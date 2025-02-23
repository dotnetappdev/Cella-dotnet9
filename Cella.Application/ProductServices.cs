using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Cella.Domain;
using Microsoft.AspNetCore.Http;
using Cella.Application.Interfaces;
namespace Cella.Application
{
    public class ProductServices : IProductInterface
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        CellaDBContext context { get; set; }
        public ProductServices(CellaDBContext _context, IHttpContextAccessor _httpContextAccessor) { 
        
            context = _context;            
            httpContextAccessor = _httpContextAccessor;

        }

        public async void AddProduct(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();
        }


        public async void UpdateProduct(Product product)
        {

              var productToUpdate = await context.Product.FindAsync(product.Id); // Fetch the entity

                if (product != null)
                {
                    context.Product.Update(product); // Marks entity as modified
                    await context.SaveChangesAsync(); // Save changes
                }           


        }
        public async void DeleteProductAsync(Product product)
        {
            var userName = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System"; // Get logged-in user

            var productToDelete = await context.Product.Where(x => x.Id == product.Id).FirstOrDefaultAsync();
            if (productToDelete !=null)
            {
                
                product.LastModifiedDate = DateTime.Now;
                productToDelete.isDeleted= true;
                if(userName !=null)
                {
                    userName = userName.Trim();
                }


               await context.SaveChangesAsync();
            }
  
        }


    }
}
