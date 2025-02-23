using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models.ViewModels
{
   public  class ThemeListItem
    {
        public int Id { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public string? ThumbnailUrl { get; set; }

        public bool? IsCurrent { get; set; }

         public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
    }
}
