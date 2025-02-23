using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Models
{
    public class LocaleStringResource
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        public int LanguageId { get; set; }
        public Guid? TenantId { get; set; }

        public Guid? StoreId { get; set; }
        /// <summary>
        /// Gets or sets the resource name
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the resource value
        /// </summary>
        public string ResourceValue { get; set; }


        public DateTime? LastModifiedDate { get; set; }

        public string? CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}
