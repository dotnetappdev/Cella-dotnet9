using Microsoft.AspNetCore.Authentication;
using Cella.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Cella.Models
{
    public class CellaAuditTrail {

        public enum AudItTypes {
            [Display(Name = "Microsoft Word")]
            Word = 1,
            [Display(Name = "Microsoft Excel")]
            Excel = 2,
            [Display(Name = "Image")]
            Image = 3,
            [Display(Name = "Voice Recordings")]
            Voice = 4,
            [Display(Name = "PDF")]
            PDF = 5,
            [Display(Name = "Video")]
            Video = 6,
            [Display(Name = "Evidence")]
            Evidence = 7,
            [Display(Name = "None")]
            None = 8,
            [Display(Name = "Notes")]
            NOTES = 9
         

        }


 

        public AudItTypes AuditTrailType { get; set; }

        public int Id { get; set; }
        [StringLength(30)]
        public string IPAddressBytes { get; set; }
        [StringLength(5000)]
        public string Update { get; set; }
        public int WarehouseId { get; set; }

        public Guid TennantId { get; set; }

        public int AuditType { get; set; }
        public int? CellaId { get; set; }
      
        [Required]
        public string Action { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(30)]
        [Display(Name = "Updated By")]
        public string CreatedBy { get; set; }

        public string OldFieldValues { get; set; }

        public string NewFieldValues { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

    }
}
