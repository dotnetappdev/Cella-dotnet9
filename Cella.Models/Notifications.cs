using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cella.Models{
   public  class Notifications {
        public int Id { get; set; }

        public string Title { get; set; }


        public string Notes { get; set; }
        public string Message { get; set; }

        public int CaseId { get; set; }

        public string Subject { get; set; }
        public string ReplyMessage { get; set; }
     

        [ForeignKey("SharedFromUser")]
        public string? SharedFrom { get; set; }
        public virtual ApplicationUser SharedFromUser { get; set; }


        [ForeignKey("SharedToUser")]
        public string? SharedTo { get; set; }
        public virtual ApplicationUser SharedToUser { get; set; }


        public bool isReply { get; set; }
        public Guid DestinationUserId { get; set; }
        public int WarehouseId { get; set; }
        public bool isRead { get; set; }


        public bool isAccepted { get; set; }

        public DateTime CreateDated { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }


    }
}
