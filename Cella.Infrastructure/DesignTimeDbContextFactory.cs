using Cella.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cella.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Adjust the base path to point to the Web API project directory
            string webApiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "../Cella.Api"); // Update with correct relative path

              IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(webApiProjectPath) // Point to the Web API project folder
                .AddJsonFile("appsettings.json")
                .Build();

            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);

             var connectionString = appSettings.GetDefaultConnection();

            // Configure the DbContext with the connection string
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
