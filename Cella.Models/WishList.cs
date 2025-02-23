using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
    public class WishList
    {


        public int Id { get; set; }

        public enum Type
        {

            Goods = 1,
            Digital = 2,
            DownLoad = 3,
            Voucher = 4,
            GitfCard = 5,
            BalancePayment = 6
        }

        //THIS IS DIFFERENT TO THE USER ID THIS IS THE CUSTOMER OF //
        //SAS PRODUCT
        public Guid? TenantId { get; set; }
        [StringLength(1000)]
        public string? StockCode { get; set; }

        public int? SupplierId { get; set; }

        [StringLength(60)]
        public string? BarCode { get; set; }
        public Guid? UserId { get; set; }
        [StringLength(5000)]
        public string? ShortDescription { get; set; }

        [StringLength(5000)]
        public string? Name { get; set; }
        public string? FullDescription { get; set; }


        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool? isDeleted { get; set; }
    }
}
