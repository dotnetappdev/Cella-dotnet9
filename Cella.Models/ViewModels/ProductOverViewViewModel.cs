using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models.ViewModels
{
    public class ProductOverViewViewModel
    {

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Sku { get; set; }
        public bool MarkAsNew { get; set; }
        public string OldPrice { get; set; }
        public string Price { get; set; }
        public decimal PriceValue { get; set; }


        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }
        public bool DisableAddToCompareListButton { get; set; }

        public bool AvailableForPreOrder { get; set; }
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        public bool IsRental { get; set; }
        public bool isDigitalDownload { get; set; }


    }
}
