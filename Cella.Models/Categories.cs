using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
    public class Categories
    {
        

        public int Id { get; set; }

        public Guid? StoreId { get; set; }
        public Guid? TennantId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public int? Type { get; set; }
        public int? ParentId { get; set; }
        public bool? isSubItem { get; set; }

        public string? Description { get; set; }
        public int? DisplayOrder { get; set; }
        public string? ShortDescription { get; set; }

        public string? Image { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeyWord { get; set; }
        public int? PageSize { get; set; }
        public bool? canCustomerSelectPageSize { get; set; }
        public bool? isShowHomePage { get; set; }
        public bool? isIncludeSideMenu { get; set; }
        public int? TotalProductsCategory { get; set; }
        public int? SortOrder { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
    }
}
