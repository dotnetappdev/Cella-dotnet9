using System;
using System.ComponentModel.DataAnnotations;

namespace Cella.Models{

    public class CreditsForApi {
        public int Id { get; set; }

        [StringLength(300)]
        public string EndPoint { get; set; }

        //stores the guid for the API Key
        public string ApiKey { get; set; }

        public long CreditsToConsume { get; set; }

        public string IpAddress { get; set; }

        public DateTime LastModifiedDate { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}