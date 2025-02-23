using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WarehouseCrm.Infrastructure;
using WarehouseCrm.Infrastructure.Modules;

namespace WarehouseCrm.Module.PaymentPaypalExpress
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            GlobalConfiguration.RegisterAngularModule("WarehouseCrm.Module.PaymentPaypalExpress");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
