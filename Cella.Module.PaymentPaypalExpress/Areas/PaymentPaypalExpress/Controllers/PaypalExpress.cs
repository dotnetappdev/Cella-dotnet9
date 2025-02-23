using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseCrm.Module.PaymentPaypalExpress.Areas.PaymentPaypalExpress.Controllers
{
    [Area("PaymentPaypalExpress")]
    public class PaypalExpress : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
