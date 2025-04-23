using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Interfaces
{
    public  interface IStockInterface
    {
        public  Task<ServiceResponse<IEnumerable<StockItem>>> GetAll();
        public ServiceResponse<string> PostStockItem(StockItemVm stockItemVm);
        public ServiceResponse<string> PutStockItem(StockItemVm stockItemVm);

        public  Task<ServiceResponse<string>> Delete(int stockId);

    }
}
