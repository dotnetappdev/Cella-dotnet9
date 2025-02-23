using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
  public  class Geozone {
        [Key]
        public int ZoneId { get; set; }
        [StringLength(50)]
        public string  Name { get; set; }
        [StringLength(50)]
        public string GroupName { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
