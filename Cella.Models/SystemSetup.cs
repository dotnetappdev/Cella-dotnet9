using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
   public  class SystemSetup {

        public int Id { get; set; }
        [StringLength(10)]
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Language { get; set; }
        
        [StringLength(600)]
        public string? SendGridApiKey { get; set; }
        [StringLength(100)]
        public string? SendGridUserName { get; set; }
        [StringLength(30)]
        public string? SendGridPassword { get; set; }

        public string? Theme { get; set; }



        [StringLength(600)]
        public string? TwilloUrl { get; set; }
        [StringLength(100)]
        public string? TwillioUserName { get; set; }
        [StringLength(30)]
        public string? TwillioPassword { get; set; }
        [StringLength(300)]
        public string? UploadFolderPath { get; set; }
        public Guid? TeannatId { get; set; }

        public bool isCatalog { get; set; }
        public bool isShowCallButton { get; set; }
        public int? GridItems { get; set; }


        [StringLength(10)]
        public string? Version { get; set; }
    }
}
