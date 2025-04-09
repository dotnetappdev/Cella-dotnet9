using Cella.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Interfaces
{
    public interface IStockInterface
    {
        public  Task<StockItem> Put(StockItem stockItem);

        public Task<StockItem> Post(StockItem stockItem);


        public void Delete(StockItem stockItem);

        public Task<List<StockItem>> GetAll();


        public Task<StockItem> GetById(int Id);

    }
}
