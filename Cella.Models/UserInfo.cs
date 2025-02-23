
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
 using System.Linq;
using System.Threading.Tasks;
namespace Cella.Models{
    public class UserInfo : IdentityUser {
        public virtual UserProfileInfo ProfileInformation { get; set; }

    }
}
