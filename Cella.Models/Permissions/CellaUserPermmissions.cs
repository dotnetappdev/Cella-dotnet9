using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cella.Models.Permissions
{
    public class CellaUserPermmissions
    {   [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Controller { get; set; }
        public string? HttpVerb { get; set; }
        public string? Area { get; set; }
        public string? Action { get; set; }
        public bool? Authorized { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        

        public string? CreatedBy { get; set; }

        public bool? isAcitve { get; set; }

        public bool? isDeleted { get; set; }

    }
}
