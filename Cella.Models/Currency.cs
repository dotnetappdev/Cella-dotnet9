using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Cella.Models.Enums;

namespace Cella.Models
{
    public class Currency
    {
        
        public int Id { get; set; }

        /// <summary>
        /// Gets the user ID
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Gets the teannat id
        /// </summary>
        public Guid? TeannatId { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the currency code
        /// </summary>
        public string? CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the rate
        /// </summary>
        public decimal? Rate { get; set; }

        /// <summary>
        /// Gets or sets the display locale
        /// </summary>
        public string? DisplayLocale { get; set; }

        /// <summary>
        /// Gets or sets the custom formatting
        /// </summary>
        public string? CustomFormatting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool? isLimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool? isPublished { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the rounding type identifier
        /// </summary>
        public int? RoundingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the rounding type
        /// </summary>
        public RoundingType RoundingType
        {
            get => (RoundingType)RoundingTypeId;
            set => RoundingTypeId = (int)value;
        }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        [StringLength(30)]
        public string? CreatedBy { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

    }
}
