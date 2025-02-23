using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models {
    public class DriverRoutes {


        public enum SafePlaceType { 
        Garage=0,
        BackPorch=1,
        FrontPorch=2,
        SideGate=3,
        SecureAccessCode=4


        }
        public int Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }

        public int? FromCella { get; set; }

        public int? DesintationAddress { get; set; }

        public int? CustomerAddress { get; set; }

        public decimal? Lattitude { get; set; }

        public decimal? Longitutde { get; set; }

        public int? NumberOFStops { get; set; }

        public FileAttachments? PhotoDelivery { get; set; }

        public int SafePlace { get; set; }

        public bool IsActive { get; set; }

        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public string   CreatedBy { get; set; }

        
    }
}
