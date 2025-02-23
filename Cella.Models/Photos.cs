using Cella.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
   public class Photos {

        public int Id { get; set; }

        public string? Filename { get; set; }

        public string? Description { get; set; }

        public string? SeverName { get; set; }


        public int? Type { get; set; }

        public int? SecurityLevel { get; set; }

        public Int32 CaseId { get; set; }

        public Int32 WarehouseId { get; set; }
        public Int32 RelationShipId { get; set; }
         public int? Postion { get; set; }

        public int RelationShipType { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? LastModifiedBy  { get; set; }
        public enum PostionEnum {
            Front =1,
            SideLeft=2,
           SideRight=3,
           FullLength=4,
           Midshot=5
        }
    }
}
