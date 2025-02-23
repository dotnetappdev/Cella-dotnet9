using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using ExtCore.Infrastructure;
using ExtCore.Mvc.Infrastructure.Actions;
using Microsoft.AspNetCore.Builder;

namespace WareHouseCrm.PaymentProcesser.PayPalStandard.Actions
{
    public class UseEndpointsAction : IUseEndpointsAction
    {
        public int Priority => 2000;

        public void Execute(IEndpointRouteBuilder endpointRouteBuilder, IServiceProvider serviceProvider)
        {
            endpointRouteBuilder.MapControllerRoute(name: "hello", pattern: "hello", defaults: new { controller = "PayPal", action = "Index" });
        }
    }
    }
