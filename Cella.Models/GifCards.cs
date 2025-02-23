using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models {
    public class GifCards {

        public int Id { get; set; }

        public string Name { get; set; }

        public int CurrencyCode { get; set; }

        public int DiscountType { get; set; }


        public decimal DiscountValue { get; set; }

        public DateTime CreatedDate { get; set; }


        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]
        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

    }
}
