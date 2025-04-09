using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.IO;
 
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Security.Claims;
 

using System.Threading;
using Cella.Models;
using Cella.Domain.Localization;

namespace Cella.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }

        

        public DbSet<Company> Companies { get; set; }

        public DbSet<Stores> Stores { get; set; }


         public DbSet<CellaAuditTrail> CellaAuditTrail { get; set; }

        public DbSet<StockItem> StockItems { get; set; }


        public DbSet<SystemSetup> SystemSetup { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Notifications> Notifications { get; set; }


        public DbSet<PluginList> Plugins { get; set; }
        public DbSet<StandardLookups> StandardLookups { get; set; }

        public DbSet<FileAttachments> FileAttachments { get; set; }

        public DbSet<AttachmentTypes> FileAttachmentTypes { get; set; }
        public DbSet<Photos> Photos { get; set; }


        public DbSet<Gender> Genders { get; set; }
        public DbSet<Countries> Countries { get; set; }

        public DbSet<StaffMembers> StaffMember { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }


        public DbSet<CustomFieldsForModels> CustomFields { get; set; }

        public DbSet<CustomFieldsDataTypes> CustomFieldsDataTypes { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
         public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<LocaleStringResource> LocaleStringResource { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Language> Language { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StaffMembers>().HasData(
         new StaffMembers() { Id = 1, FirstName = "David", LastName = "Buckley", isActive = true, isDeleted = false },
         new StaffMembers() { Id = 2, FirstName = "Martha", LastName = "Jones", isActive = true, isDeleted = false },
         new StaffMembers() { Id = 3, FirstName = "Jane", LastName = "Smith", isActive = true, isDeleted = false }

         );
       
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(4);
            }
        

        //lets add a global filter to the query we will alwayss be checking 
        //isdelete=true and isdeleted false will need to do this for all entitys
        modelBuilder.Entity<SalesOrder>().HasQueryFilter(q => q.isDeleted == false && q.isActive == true);
            modelBuilder.Entity<SalesOrderItem>().HasQueryFilter(q => q.isDeleted == false && q.isActive == true);
            modelBuilder.Entity<Currency>().HasQueryFilter(q => q.isDeleted == false && q.isActive == true);


            
            modelBuilder.Entity<SystemSetup>().HasData(
         new SystemSetup() { Id = 1, UploadFolderPath = @"~\Uploads\" });



        }
        public  int SaveChangesSoftDelete()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }
        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["isDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["isDeleted"] = true;
                        break;
                }
            }
        }
        public void AddAudtiTrail(int caseId, string action, string user)
        {

            CellaAuditTrail _auditrail = new CellaAuditTrail();
            Guid.TryParse(user, out Guid resultUser);
            _auditrail.WarehouseId = caseId;
            _auditrail.TennantId = resultUser;
            _auditrail.CreatedBy = user;
            _auditrail.Action = action;
            _auditrail.CreatedDate = DateTime.Now;
            _auditrail.isActive = true;
            _auditrail.isDeleted = false;

            this.Add(_auditrail);
            this.SaveChangesAsync();
        }
    }

}
