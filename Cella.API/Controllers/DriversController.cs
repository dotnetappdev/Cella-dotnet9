using Cella.Infrastructure;
using Cella.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cella.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetDrivers()
        {
            return _context.Customers.Where(c => c.CustomerType == Customer.TypeOfCustomer.Driver).ToList();
        }

        [HttpPost]
        public IActionResult AddDriver([FromBody] Customer driver)
        {
            driver.CustomerType = Customer.TypeOfCustomer.Driver;
            _context.Customers.Add(driver);
            _context.SaveChanges();
            return Ok(driver);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetDriver(int id)
        {
            var driver = _context.Customers.FirstOrDefault(c => c.Id == id && c.CustomerType == Customer.TypeOfCustomer.Driver);
            if (driver == null) return NotFound();
            return driver;
        }

        [HttpPost("update-gps")]
        public IActionResult UpdateDriverGps([FromBody] UpdateGpsRequest req)
        {
            var driver = _context.Customers.FirstOrDefault(c => c.Id == req.DriverId && c.CustomerType == Customer.TypeOfCustomer.Driver);
            if (driver == null) return NotFound();
            driver.GpsLocation = req.GpsLocation;
            _context.SaveChanges();
            return Ok();
        }
        public class UpdateGpsRequest { public int DriverId { get; set; } public string GpsLocation { get; set; } }

        [HttpPost("update-stops")]
        public IActionResult UpdateStops([FromBody] UpdateStopsRequest req)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == req.CustomerId);
            if (customer == null) return NotFound();
            customer.StopsUntilThisStop = req.Stops;
            _context.SaveChanges();
            return Ok();
        }
        public class UpdateStopsRequest { public int CustomerId { get; set; } public int Stops { get; set; } }

        [HttpPost("update-status-location")]
        public IActionResult UpdateDriverStatusLocation([FromBody] UpdateStatusLocationRequest req)
        {
            var driver = _context.Set<Drivers>().FirstOrDefault(d => d.Id == req.DriverId);
            if (driver == null) return NotFound();
            driver.RouteStatus = req.RouteStatus;
            driver.LastKnownLocation = req.LastKnownLocation;
            _context.SaveChanges();
            return Ok();
        }
        public class UpdateStatusLocationRequest { public int DriverId { get; set; } public string RouteStatus { get; set; } public string LastKnownLocation { get; set; } }

        [HttpGet("status/{driverId}")]
        public IActionResult GetDriverStatus(int driverId)
        {
            var driver = _context.Set<Drivers>().FirstOrDefault(d => d.Id == driverId);
            if (driver == null) return NotFound();
            return Ok(new { driver.Id, driver.FirstName, driver.LastName, driver.RouteStatus, driver.LastKnownLocation, driver.CurrentStop, driver.TotalStops });
        }
    }
}
