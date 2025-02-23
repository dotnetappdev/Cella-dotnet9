using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Cella.Models
{
    public class ShoppingCart
    { 

        public enum StatusType
        {
            Temp=1,//temp means do not make the status peristant
            Order=2// this is a now order and should be copied into sales orders


        }
        public int Id { get; set; }

        public string SessionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? CartId { get; set; }
        public Guid? TeannatId { get; set; }
        
        public Guid? UserId { get; set; }

        public Address?  Customer { get; set; }

        public Address? DeliveryCustomer { get; set; }
        public GifCards? GiftCardApplied { get; set; }

        public List<ShoppingCartItems>? Items { get; set; }
        public decimal? SubTotal { get; set; }
        

        public int? Vat { get; set; }

        public decimal? Total { get; set; }


        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public decimal? Length { get; set; }

        public decimal? Depth { get; set; }
        [StringLength(20)]
        public string? CreatedBy { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isActive { get; set; }


        public DateTime CreateDate { get; set; }


        
    }

}
