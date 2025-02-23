using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cella.Models{
 public   class StandardLookups  {

        public int Id { get; set; }

        public int? LookupGroup { get; set; }

        public string? LoookUpGroupDescription { get; set; }
        public int? LookupSubGroup { get; set; }

        public int? LookupSubGroup_SecondLevel { get; set; }
        public string? LookupDescription { get; set; }
        public string?   LookupText { get; set; }       
         
    }
}
