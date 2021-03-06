using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CrudAssignment.Entities.Models.Mapping;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public partial class CrudAssignmentContext : DataContext
    {
        static CrudAssignmentContext()
        {
            Database.SetInitializer<CrudAssignmentContext>(null);
        }

        public CrudAssignmentContext()
            : base("Name=CrudAssignmentContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
        }
    }
}
