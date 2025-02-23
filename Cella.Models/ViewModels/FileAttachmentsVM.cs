using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cella.Models{
   public  class FileAttachmentsVM {
        public enum FileAttachmentTypes {
            [Display(Name = "Vessel")]
            Vessel = 21,
            [Display(Name = "Person Of Intrest")]
            Poi = 22,
            [Display(Name = "Case")]
            Case = 23,
            [Display(Name = "Passport Documents")]
            Passport = 25,
            [Display(Name = "Certificates")]
            Certificates = 26,
            [Display(Name = "Licenses")]
            Licences = 27,
            [Display(Name = "Witness Statements")]
            WitnessStatements = 28,
            [Display(Name = "Photo Evidence")]
            PhotoEvidence = 29



        }

        public enum PhotoTypesPoi {
            [Display(Name = "PhotoProfile")]
            Front = 1,
            Side = 2,
            Left = 3,
            Right = 4
        }
        public PhotoTypesPoi PhotoFileTypePoi { get; set; }


        public FileAttachmentTypes FileAttachmentType { get; set; }

        public int Id { get; set; }
          public DateTime UploadedDate { get; set; }
        public Guid TennantId { get; set; }

        public string DocumentPath { get; set; }

        public string ServerIpAddress { get; set; }

        public string OrignalFileName { get; set; }
        public string FolderPath { get; set; }

        [ForeignKey("StaffMembersOIC1")]
        public string? OIC_1 { get; set; }
        public virtual ApplicationUser StaffMembersOIC1 { get; set; }
        [NotMappedAttribute]
        public IFormFile File { set; get; }
        public int CaseId { get; set; }

        public string FullPath { get; set; }
        public string ContentType { get; set; }
      

        [ForeignKey("UploadedByUser")]
        public string? UploadedBy { get; set; }

        public virtual ApplicationUser UploadedByUser { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal FileSize { get; set; }

        public string IconFile { get; set; }

        public string Extension { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
         [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
