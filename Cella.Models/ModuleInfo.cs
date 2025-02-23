using System;
using System.Reflection;

namespace Cella.Models
{
    public class ModuleInfo
    {
        public enum ModuleType
        {
            CMS=1,
            STOCK=2,
            SALES=3,
            PaymentProcess=4

        }

        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsBundledWithHost { get; set; }
        public string Thumbnail { get; set; }

        public int   Order { get; set; }

        public int Type { get; set; }
        public string isEnabled { get; set; }

        public Version Version { get; set; }

        public Assembly Assembly { get; set; }
    }
}
