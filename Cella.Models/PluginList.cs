using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Cella.Models
{
    public class PluginList
    {
        public enum PlugInType
        {
            CMS=1,
            STOCK=2,
            SALES=3,
            PaymentProcess=4

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ModuleId { get; set; }
        public string Name { get; set; }

        public bool IsBundledWithHost { get; set; }
        public string Thumbnail { get; set; }

        public int   Order { get; set; }

        public int Type { get; set; }
        public string isEnabled { get; set; }

        public string Version { get; set; }

        
    }
}
