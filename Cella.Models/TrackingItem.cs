using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models {
   public  class TrackingItem {

        public int Id { get; set; }

        public Guid? StoreId { get; set; }
        public Guid? UserId { get; set; }
        public Product StockItem { get; set; }
       [StringLength(50)]
        public string StockCode { get; set; }
       [StringLength(500)]
        public string Description { get; set; }

        public bool ScannedOn { get; set; }
        public int Qty { get; set; }

        public decimal LinePrice { get; set;  }
        [StringLength(10)]
        public string Currency { get; set; }

       public DateTime? OrderDate { get; set; }
       public DateTime? CreateDate { get; set; }
       public DateTime? LastModifiedDate { get; set; }
       [StringLength(30)]
       public string? CreatedBy { get; set; }

        public DateTime DeliveryDate { get; set; }
        public virtual Photos DeliveryEvidence { get; set; }

        public bool isActive { get; set; }

       public bool isDeleted { get; set; }


    }
}
