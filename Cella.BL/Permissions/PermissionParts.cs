using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.BL.Permissions
{
    public static class Permissions
    {
        public static class StockItems
        {
            public const string View = "Permissions.StockItems.View";
            public const string Create = "Permissions.StockItems.Create";
            public const string Edit = "Permissions.StockItems.Edit";
            public const string Delete = "Permissions.StockItems.Delete";
        }
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.Create",
                $"Permissions.{module}.View",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
            };
        }


    }
}
