using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
   public class ThemesSetup
    {

        public int Id { get; set; }

        public string? Titlte { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Description { get; set; }

        public string? ThumbNail { get; set; }


        public string? Version { get; set; }

        public string? Author { get; set; }

        public bool? CurrentTheme { get; set; }

        [StringLength(20)]
        public string? CreatedBy { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isActive { get; set; }


        public DateTime? CreateDate { get; set; }


    }
}
