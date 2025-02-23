using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
   public static class AppConfig
    {

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }

        public static IList<ModuleInfo> Modules { get; set; } = new List<ModuleInfo>();


    }
}
