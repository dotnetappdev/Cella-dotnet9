using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models {
   public class Drivers {


       public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }

        [Required]
        public int RouteId { get; set; }
       [StringLength(300)]
        public string? FirstName { get; set; }
        [StringLength(300)]
        public string? Middle { get; set; }
        [StringLength(300)]
        public string? LastName { get; set; }
       public int? CurrentStop { get; set; }
       public int? TotalStops { get; set; }

       public DateTime CreateDate { get; set; }


        public string DailingCountryCode { get; set; }

        public string MobileNumber { get; set; }

        public bool isBusinessMobile { get; set; }

        public bool isPersonalMobile { get; set; }

        public bool canSms { get; set; }

        public bool canCall { get; set; }
        public string? OldValues { get; set; }

       public string? NewValues { get; set; }



       public DateTime LastModifiedDate { get; set; }
       [StringLength(30)]

       public string CreatedBy { get; set; }

       public bool isActive { get; set; }

       public bool isDeleted { get; set; }

    }
}
