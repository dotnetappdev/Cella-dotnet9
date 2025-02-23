using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cella.Models
{
   public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string?  Controller { get; set; }

        public string? Action { get; set; }


    }
}
