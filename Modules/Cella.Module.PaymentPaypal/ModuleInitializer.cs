using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Cella.BL.Interfaces;
using Cella.BL.Services;
using Cella.Infrastructure;
using Cella.Infrastructure.Modules;

namespace Cella.Module.PaymentPaypal
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            GlobalConfiguration.RegisterAngularModule("Cella.Module.PaymentPaypal");

            serviceCollection.AddTransient<IThemeService, ThemeService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
