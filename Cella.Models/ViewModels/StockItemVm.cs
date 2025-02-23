using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;
using System.Text;
using Cella.Models.Permissions;

namespace Cella.Models {

    [Keyless]
    public class StockItemVm {
        
        public List<CellaUserPermmissions> UserPermissions { get; set; }

       
        public List<Product> StockItems { get; set; }

    }
}
