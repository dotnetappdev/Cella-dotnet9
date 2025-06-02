using Cella.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cella.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("sample")]
        public ActionResult<IEnumerable<StockItem>> GetSampleProducts()
        {
            var products = new List<StockItem>
            {
                new StockItem { Id = 1, Name = "Widget A", Price = "9.99", ShortDescription = "A great widget.", Categories = 1, StockCode = "WIDGETA" },
                new StockItem { Id = 2, Name = "Widget B", Price = "14.99", ShortDescription = "A better widget.", Categories = 1, StockCode = "WIDGETB" },
                new StockItem { Id = 3, Name = "Gadget C", Price = "19.99", ShortDescription = "A cool gadget.", Categories = 2, StockCode = "GADGETC" },
                new StockItem { Id = 4, Name = "Gadget D", Price = "24.99", ShortDescription = "A premium gadget.", Categories = 2, StockCode = "GADGETD" }
            };
            return Ok(products);
        }
    }
}
