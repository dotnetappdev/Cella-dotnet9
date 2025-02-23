using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.BL.Interfaces;
using Warehouse.BL.Services;
using WarehouseCrm.Infrastructure;
using WarehouseCrm.Infrastructure.Modules;

namespace WarehouseCrm.Module.PaymentPaypal
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            GlobalConfiguration.RegisterAngularModule("WarehouseCrm.Module.PaymentPaypal");

            serviceCollection.AddTransient<IThemeService, ThemeService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
