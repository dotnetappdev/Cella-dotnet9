using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
 

namespace Cella.Module.PaymentPaypal.Controllers
{
  
    public class PaypalExpress :  Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
