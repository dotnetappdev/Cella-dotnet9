using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
  public   class CheckoutAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Guid? StoreId { get; set; }

        public string? UerId { get; set; }
        public string TextPrompt { get; set; }

       
        public bool IsRequired { get; set; } 
  
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the default value (for textbox and multiline textbox)
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets a condition (depending on other attribute) when this attribute should be enabled (visible).
        /// </summary>
        public string ConditionAttributeXml { get; set; }

      
    }
}
