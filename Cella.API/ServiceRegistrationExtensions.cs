using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Cella.Domain;
using Microsoft.EntityFrameworkCore;
using Cella.Models;


namespace Cella.API
{
    public static class ServiceRegistrationExtensions
    {
        // Register DbContext and Identity with SQL Server
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register ApplicationDbContext with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register Identity services with ApplicationDbContext
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            
            services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
            // Additional application-level services, e.g., email service, caching, etc.
           services.AddEndpointsApiExplorer();

        }

        // Register custom application services (e.g., business logic services)
        public static void AddBusinessServices(this IServiceCollection services)
        {
 

        }

        // Register other services like controllers, health checks, etc.
        public static void AddControllerServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();

            services.AddSwaggerGen(); // Swagger registration (optional)
        }

        // Register application-specific middlewares (optional)
        public static void AddApplicationMiddlewares(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://example.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
