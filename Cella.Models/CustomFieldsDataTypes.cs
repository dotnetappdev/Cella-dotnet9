using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models{
    public class CustomFieldsDataTypes {

        public int Id { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Type { get; set; }

        public string? Description { get; set; }

        public bool? IsRequired { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string? CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }


    }
}
