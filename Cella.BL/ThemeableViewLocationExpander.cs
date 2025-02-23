using System.Collections.Generic;
using System.Linq;
using Cella.Domain;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Warehouse.Domain;

 
namespace Cella.BL
{
public class ThemeableViewLocationExpander : IViewLocationExpander
{

         
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        // string theme=  AppSettingsManger.Configuration.GetSection("theme").Get<string>();
        context.Values.TryGetValue(Constants.ThemeConfigKey, out string theme);



        if (!string.IsNullOrWhiteSpace(theme) && !string.Equals(theme, "Generic", System.StringComparison.InvariantCultureIgnoreCase))
        {
            var moduleViewLocations = new string[]
            {
                $"/Themes/{theme}/Areas/{{2}}/Views/{{1}}/{{0}}.cshtml",
                $"/Themes/{theme}/Areas/{{2}}/Views/Shared/{{0}}.cshtml",
                $"/Views/Admin/{{1}}/{{0}}.cshtml",

                $"/Themes/{theme}/Views/{{1}}/{{0}}.cshtml",
                $"/Themes/{theme}/Views/Shared/{{0}}.cshtml"
            };

            viewLocations = moduleViewLocations.Concat(viewLocations);
        }

        return viewLocations;
    }


    public void PopulateValues(ViewLocationExpanderContext context)
    {
       

          
        var controllerName = context.ActionContext.ActionDescriptor.DisplayName;
        if (controllerName == null) // in case of render view to string
        {
            return;
        }
           
        var config = context.ActionContext.HttpContext.RequestServices.GetService<IConfiguration>();
        context.Values[Constants.ThemeConfigKey] = config["Theme"];


    }
}
}

