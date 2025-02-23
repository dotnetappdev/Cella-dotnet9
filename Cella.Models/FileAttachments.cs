using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cella.Models{
   public  class FileAttachments {

    public enum FileAttachmentTypes {

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
        NOTES = 9,
        [Display(Name = "Shared Case")]
        SharedCase = 10,
        [Display(Name = "Created Case")]
        CreatedCase = 11
    }

        public enum PhotoTypesPoi {
            [Display(Name = "PhotoProfile")]
            Front=1,
            Side=2,
            Left=3,
            Right=4
        }

        //while vessel has an upload area so does two sub sections
        public enum UploadAreEnum {
            FileAttachments = 1,
            Poi = 2,
            Vessel = 3,
            Commercial=4,
            NonCommercial = 5
        }
        public int UploadAreaId { get; set; }
        public UploadAreEnum UploadArea {
            get => (UploadAreEnum)UploadAreaId;
            set => UploadAreaId = (int)value;
        }

        
        public PhotoTypesPoi PhotoFileTypePoi { get; set; }

        
        public FileAttachmentTypes FileAttachmentType { get; set; }

        public int Type { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid TennantId { get; set; }
        public int CaseId { get; set; }
        public int? PoiID { get; set; }
 

        public string FullPath { get; set; }
        public string ContentType { get; set; }
        public string DocumentPath { get; set; }

        public string FileAction { get; set; }
        public string ServerIpAddress { get; set; }

        public string OrignalFileName { get; set; }
        public string FolderPath { get; set; }
        public string File { set; get; }


        [ForeignKey("UploadedByUser")]
        public string? UploadedBy { get; set; }

        public virtual ApplicationUser UploadedByUser { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal FileSize { get; set; }

        public bool isDefaultImage { get; set; }
        public string IconFile { get; set; }

        public string Extension { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
        [Required(ErrorMessage = "Created Date is Required")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

   
        //public int? StockPhotosForeignKey { get; set; }
        //public StockItemVm StockPhotos { get; set; }


        public string CreatedBy { get; set; }
    }
}
