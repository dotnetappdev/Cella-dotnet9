using Cella.Domain.Interfaces;
using Cella.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cella.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        IStockInterface _stockInterface;
        public StockController(IStockInterface stockInterface)
        {
            _stockInterface = stockInterface;
        }
        // GET: api/<StockController>
        [HttpGet]
        public async Task<IEnumerable<StockItem>> Get()
        {
            return await _stockInterface.GetAll();
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockController>
        [HttpPost]
        public void Post(StockItemVm stockItemVm)
        {

               _stockInterface.PostStockItem(stockItemVm);


        }

        // PUT api/<StockController>/5
        [HttpPut]
        public void Put(StockItemVm stockItemVm)
        {
            _stockInterface.PutStockItem(stockItemVm);

        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
            _stockInterface.Delete(id);
        }
    }
}
