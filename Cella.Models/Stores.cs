using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cella.Models
{
    public class Stores
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? StoreId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public string? Domain { get; set; }


        public string? IPAddress { get; set; }

        public Customer AdminContact { get; set; }

        public DateTime LastMofiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool isAcitve { get; set; }

        public bool isDeleted { get; set; }
    }
}
