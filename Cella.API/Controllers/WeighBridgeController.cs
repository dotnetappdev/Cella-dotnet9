using Microsoft.AspNetCore.Mvc;
using Cella.Models;
using Cella.Infrastructure;
using System.Linq;

namespace Cella.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeighBridgeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WeighBridgeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Set<WeighBridgeEntry>().ToList());

        [HttpPost]
        public IActionResult Add([FromBody] WeighBridgeEntry entry)
        {
            if (entry == null) return BadRequest();
            _context.Add(entry);
            _context.SaveChanges();
            return Ok(entry);
        }
    }
}
