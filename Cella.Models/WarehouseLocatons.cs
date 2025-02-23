using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
    public class WarehouseLocatons
    {

        public int Id { get; set; }

        public int? WarehouseNumber { get; set; }
        public Guid? UserId { get; set; }

        public Guid? TeannatId { get; set; }

        public string? BarCode { get; set; }
 
        public string? Name { get; set; }

        public string? Description { get; set; }
        public List<WarehouseLocationItems> WarehouseLocationItems { get; set; }

      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



        public int Address { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]
        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

    }
}
