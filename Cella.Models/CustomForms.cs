using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models
{
    public class CustomForms
    {
        public int Id { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Type { get; set; }

        public string? Description { get; set; }

        public List<CustomFieldsForModels>? CustomFields { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [StringLength(30)]

        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}
