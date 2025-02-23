using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Infrastructure.Models.Plugins
{
   public  class PluginList
    {

        public enum PluginType { 
            
            }

        public int Id { get; set; }

        public string Name { get; set; }


        public string Version { get; set; }

        public string Author { get; set; }

        public int DisplayOrder { get; set; }

        
        public bool IsEnabled { get; set; }
        public string LogoUrl { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }


    }
}
