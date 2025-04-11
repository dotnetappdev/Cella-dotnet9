using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace Cella.Models
{
 
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

    }

}
