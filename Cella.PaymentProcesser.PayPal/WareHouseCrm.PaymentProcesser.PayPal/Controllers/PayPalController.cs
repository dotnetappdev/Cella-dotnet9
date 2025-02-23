using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseCrm.PaymentProcesser.PayPalStandard.Controllers
{
   public class PayPalController :Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
