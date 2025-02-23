using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cella.Models{
    
    public class Company   {

        public int Id { get; set; }
        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }

        [StringLength(500)]
        [Required]

        [DisplayName("Company Name")]

        public string? CompanyName { get; set; }


        [JsonProperty("CompanyAddress1")]
        [DisplayName("Address 1")]
        public string? CompanyAddress1 { get; set; }
        [DisplayName("Address 2")]
        [JsonProperty("CompanyAddress2")]
        public string? CompanyAddress2 { get; set; }
        [DisplayName("Address City")]
        [JsonProperty("CompanyCity")]
        public string? CompanyCity { get; set; }
        [JsonProperty("CompanyPostCode")]
        [DisplayName("Post Code")]
        public string? CompanyPostCode { get; set; }

        [DisplayName("Imo Number")]
        public string? IMOCompanyNumber { get; set; }
        [DisplayName("County Of Registration")]
        public string? CountryofRegistration { get; set; }

        public int Country { get; set; }


        public bool? isDeleted { get; set; }
        public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        [StringLength(2)]
        public string? CreatedBy { get; set; }

    }
}
