using Microsoft.AspNetCore.Mvc;
using Cella.Models;
using Cella.Infrastructure;
using System.Linq;

namespace Cella.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillOfMaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BillOfMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Set<BillOfMaterials>().ToList());
    }
}
