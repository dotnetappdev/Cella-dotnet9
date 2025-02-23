using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Warehouse.Infrastructure.Modules;

namespace SimplCommerce.Module.SampleData
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
      }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
