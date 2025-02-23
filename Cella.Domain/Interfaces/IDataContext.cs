using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cella.Models;

namespace Cella.Domain.Interfaces
{
   public  interface IDataContext
    {

        public DbSet<Company> Companies { get; set; }



        public DbSet<CellaAuditTrail> CellaAuditTrail { get; set; }

        public DbSet<Product> StockItems { get; set; }


        public DbSet<SystemSetup> SystemSetup { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<StandardLookups> StandardLookups { get; set; }

        public DbSet<FileAttachments> FileAttachments { get; set; }

        public DbSet<AttachmentTypes> FileAttachmentTypes { get; set; }
        public DbSet<Photos> Photos { get; set; }


        public DbSet<Gender> Genders { get; set; }
        public DbSet<Countries> Countries { get; set; }

        public DbSet<StaffMembers> StaffMember { get; set; }

    

        public DbSet<CustomFieldsForModels> CustomFields { get; set; }

        public DbSet<CustomFieldsDataTypes> CustomFieldsDataTypes { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItems> ShoppingCartsItems { get; set; }
    }
}
