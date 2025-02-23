using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Configuration
{
    public class EFConfigProvider : ConfigurationProvider
    {
        private Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }
 
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<CellaDBContext>();
            OptionsAction(builder);

            using (var dbContext = new CellaDBContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                Data = !dbContext.Appsettings.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.Appsettings.ToDictionary(c => c.Key, c => c.Value);
            }
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(CellaDBContext dbContext)
        {
            var configValues =
                new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {            
                { "Theme", "FrontEnd" },
                { "AdminTheme", "Default" },
                    { "ApiSecret","db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw=="},
                    {"Global.AssetVersion","1.0" },
                    {"Global.CatalogOnly" ,"true"},
                    {"Global.CurrencyCulture" ,"en-US"},
                    {"Global.CurrencyDecimalPlace" ,"2"},
                    {"Global.DefaultCultureUI" ,"en-US"},
                    {"ThemesFolderName" ,"Themes"},

                    
                };
            dbContext.Appsettings.AddRange(configValues
                .Select(kvp => new AppSettings
                {
                    Key = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());
            dbContext.SaveChanges();
            return configValues;
        }
    }
}
