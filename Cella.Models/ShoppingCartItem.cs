using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{

    public partial class ShoppingCartItems
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string? StockCode { get; set; }
        public Guid? CartId { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }

        [StringLength(250)]
        public string? Sku { get; set; }

        [StringLength(5000)]
        public string? VendorName { get; set; }

        [StringLength(5000)]
        public string StockDescription { get; set; }

        [StringLength(10000)]
        public string Notes { get; set; }
        public FileAttachments? Photo { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductSeName { get; set; }
        public string? UnitPrice { get; set; }

        public decimal? LinQty { get; set; }

        public decimal? LinePrice { get; set; }

        public decimal? SubTotal { get; set; }

        public string? Discount { get; set; }

        public int? MaximumDiscountedQty { get; set; }

        public int? CellaLocation { get; set; }


        public bool? ShowStockCode { get; set; }
        public bool? ShowProductImages { get; set; }
        public bool? IsEditable { get; set; }


        public DateTime? LastModifiedDate { get; set; }

        public String? LastModifiedBy { get; set; }
        public string? CreatedBy { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isActive { get; set; }


        public DateTime? CreateDate { get; set; }
        public decimal? Total { get; set; }


        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public decimal? Length { get; set; }

        public decimal? Depth { get; set; }



    }
}
