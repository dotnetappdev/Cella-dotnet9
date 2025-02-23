using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cella.Models {
    public class PriceLists {

        public enum PricListTypeEnum
        {
        StandardPrice=1,            
        SpecialPrices=2
        


        }

        public int Id { get; set; }
        [StringLength(50)]
        public string? StockCode { get; set; }


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public int PriceListType { get; set; }

        public int PriceListVersion { get; set; }
        [StringLength(4)]
        public string? CurrencyCode { get; set; }

        public decimal Price { get; set; }

        public DateTime? LastModifiedDate { get; set; }


        public string OldValues { get; set; }

        public string NewValues { get; set; }

        public string? CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

    }
}
