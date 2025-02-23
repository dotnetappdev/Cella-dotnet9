using System;
using System.Collections.Generic;
using System.Text;
using Cella.Models.Permissions;

namespace Cella.Models.ViewModels
{
    public class PermissionsViewModel
    {
        public string RoleId { get; set; }
        public IList<RoleClaimsViewModel> RoleClaims { get; set; }
    }
        public class RoleClaimsViewModel
        {
            public string Type { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
   
}
