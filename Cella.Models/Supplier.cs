using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
    public class Supplier
    {

        public int Id { get; set; }

        public string? Name { get; set; }


        public Guid Tenant { get; set; }
        public int? SupllierAddress { get; set; }


        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? County { get; set; }


        public int? Country { get; set; }

        public decimal? Lat { get; set; }

        public decimal? Long { get; set; }


        public bool? CanSupplierBackOrder { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }


        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
