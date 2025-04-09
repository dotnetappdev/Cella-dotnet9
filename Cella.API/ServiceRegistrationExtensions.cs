using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Cella.Domain;
using Microsoft.EntityFrameworkCore;
using Cella.Models;
using Cella.Infrastructure;
using Cella.Domain.Interfaces;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;



namespace Cella.API
{
    public static class ServiceRegistrationExtensions
    {
        // Register DbContext and Identity with SQL Server
        public static void AddApplicationServices(this IServiceCollection services,string connectionstring)
        {
            // Register ApplicationDbContext with SQL Server
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionstring));

            services.AddIdentityApiEndpoints<ApplicationUser>()
           .AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

               services.AddEndpointsApiExplorer();

        }

        // Register custom application services (e.g., business logic services)
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IStockInterface, StockService>();


        }

        // Register other services like controllers, health checks, etc.
        public static void AddControllerServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddControllers();
            services.AddOpenApi();

            services.AddSwaggerGen(); // Swagger registration (optional)

            var jwtSettings = appSettings.ConnectionStrings.FirstOrDefault();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSecret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.Issuer,
                    ValidAudience = appSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
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
