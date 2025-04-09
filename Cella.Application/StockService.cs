using Cella.Domain.Interfaces;
using Cella.Infrastructure;
using Cella.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Cella.Domain.Interfaces
{
    public class StockService : IStockInterface
    {
        private readonly ApplicationDbContext dbContext;
        public StockService(ApplicationDbContext _context)
        {
            dbContext = _context;

            if (dbContext == null)
            {
                throw new InvalidOperationException("DbContext is not initialized.");
            }
        }

        public Task<List<StockItem>> GetAll()
        {         
            return  dbContext.StockItems.ToListAsync(); 
        }

        public async Task<StockItem> GetById(int Id)
        {           
            return await dbContext.StockItems.FindAsync(Id);
        }


        public async Task<StockItem> Post(StockItem stockItem)
        {
            dbContext.Add(stockItem);
            await dbContext.SaveChangesAsync();  // Use async version for better performance
            return await dbContext.StockItems.FindAsync(stockItem.Id);
        }

       public void Delete(StockItem stockItem)
       {          
            var stockItemToRemove = dbContext.StockItems.Find(stockItem.Id);
            if (stockItemToRemove != null)
            {
                stockItemToRemove.isDeleted = true;
                dbContext.SaveChangesAsync();
            }

        }

         public async Task<StockItem> Update(StockItem stockItem)
        {
            dbContext.StockItems.Update(stockItem);
            dbContext.SaveChangesAsync();
            return await dbContext.StockItems.Where(w => w.Id == stockItem.Id).FirstOrDefaultAsync();

        }

        public Task<StockItem> Put(StockItem stockItem)
        {
            throw new NotImplementedException();
        }
    }
}
