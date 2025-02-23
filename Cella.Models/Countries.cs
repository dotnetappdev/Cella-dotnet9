using System;
using System.Collections.Generic;

using System.Text;

namespace Cella.Models{
   public class Countries {
        public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string Iso2 { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Unicode { get; set; }
        public string Dial { get; set; }
        public string Currency { get; set; }
        public string Capital { get; set; }
        public string Continent { get; set; } 


    }
}
