using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;
using System.Text;
using Cella.Models.Permissions;

namespace Cella.Models {

    [Keyless]
    public class StockItemVm {
        public int? Id { get; set; }

        public string? Description { get; set; }

        public string? StockCode { get; set; }
        public string? BarCode { get; set; }
        [StringLength(2000)]
        public string? ShortDescription { get; set; }

        public decimal? Price { get; set; }

        public string? Name { get; set; }
        public string? FullDescription { get; set; }
        [StringLength(5000)]
        public int? Categories { get; set; }
        [StringLength(5000)]
        public string? Manufactures { get; set; }
        public DateTime? AvailableStartDate { get; set; }


        public DateTime? AvailableEndDate { get; set; }
        public bool? isShowCallButton { get; set; }
        public bool? isNew { get; set; }
        [StringLength(1000)]

        public bool? isShowOnHomePage { get; set; }

        public int? StockItemType { get; set; }
        public bool? isShowPrice { get; set; }

        public bool? canAddToCart { get; set; }

        public bool? isPublished { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal? DefaultPrice { get; set; }
        public int? PriceList { get; set; }
        public int? PriceListType { get; set; }
        public string? SKU { get; set; }

        public int? StockQty { get; set; }
        public bool? isFeatured { get; set; }
        public bool? isBackOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public bool IsActiveDisplay => isActive ?? false;
        public bool IsDeletedDisplay => isDeleted ?? false;

    }
}
