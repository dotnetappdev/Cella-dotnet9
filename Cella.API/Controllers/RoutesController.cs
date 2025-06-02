using Cella.Infrastructure;
using Cella.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cella.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverRoutes>> GetRoutes()
        {
            return _context.Set<DriverRoutes>().ToList();
        }

        [HttpPost]
        public IActionResult AddRoute([FromBody] DriverRoutes route)
        {
            _context.Set<DriverRoutes>().Add(route);
            _context.SaveChanges();
            return Ok(route);
        }

        [HttpPost("assign-driver")]
        public IActionResult AssignDriverToRoute([FromBody] AssignDriverRouteRequest req)
        {
            var driver = _context.Customers.FirstOrDefault(c => c.Id == req.DriverId && c.CustomerType == Customer.TypeOfCustomer.Driver);
            var route = _context.Set<DriverRoutes>().FirstOrDefault(r => r.Id == req.RouteId);
            if (driver == null || route == null) return NotFound();
            driver.RouteId = req.RouteId;
            route.DriverId = req.DriverId;
            if (req.CustomerId != null)
                route.CustomerId = req.CustomerId;
            // Optionally set status/location
            var driverEntity = _context.Set<Drivers>().FirstOrDefault(d => d.Id == req.DriverId);
            if (driverEntity != null)
            {
                driverEntity.RouteStatus = "OnRoute";
                driverEntity.LastKnownLocation = route.LastStopLocation;
            }
            _context.SaveChanges();
            return Ok();
        }
        public class AssignDriverRouteRequest { public int DriverId { get; set; } public int RouteId { get; set; } public int? CustomerId { get; set; } }

        // New endpoint: Get all drivers' statuses and locations for managers/warehouse
        [HttpGet("drivers-status")]
        public ActionResult<IEnumerable<object>> GetAllDriversStatus()
        {
            var drivers = _context.Set<Drivers>().Where(d => d.isActive && !d.isDeleted).ToList();
            var result = drivers.Select(d => new {
                d.Id,
                d.FirstName,
                d.LastName,
                d.RouteStatus,
                d.LastKnownLocation,
                d.CurrentStop,
                d.TotalStops
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<DriverRoutes> GetRoute(int id)
        {
            var route = _context.Set<DriverRoutes>().FirstOrDefault(r => r.Id == id);
            if (route == null) return NotFound();
            return route;
        }
    }
}
