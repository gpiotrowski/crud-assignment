using CrudAssignment.Entities.Models;
using Microsoft.AspNet.Identity;
using Repository.Pattern.Infrastructure;

namespace CrudAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudAssignment.Entities.Models.CrudAssignmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrudAssignment.Entities.Models.CrudAssignmentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var passwordHash = new PasswordHasher();
            context.AspNetUsers.AddOrUpdate(u => u.UserName,
                new AspNetUser
                {
                    Id = "f5df20ea-4c5d-450e-b678-2adfe7111a54",
                    Email = "user@test.contoso",
                    EmailConfirmed = false,
                    PasswordHash = passwordHash.HashPassword("Pa$$w0rd"),
                    SecurityStamp = "6254a792-95f0-4625-a60e-7f43e6d045b2",
                    PhoneNumberConfirmed = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    UserName = "TestUser",
                    ObjectState = ObjectState.Added
                }
            );

            context.Categories.AddOrUpdate(c => c.Name,
                new Category
                {
                    Id = 1,
                    Name = "Category 1",
                    ObjectState = ObjectState.Added
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2",
                    ObjectState = ObjectState.Added
                }
            );

            context.Suppliers.AddOrUpdate(s => s.Name,
                new Supplier
                {
                    Id = 1,
                    Name = "Supplier 1",
                    ObjectState = ObjectState.Added
                },
                new Supplier
                {
                    Id = 2,
                    Name = "Supplier 2",
                    ObjectState = ObjectState.Added
                }
            );

            context.Products.AddOrUpdate(p => p.Id,
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "milk",
                    Price = new decimal(1.00),
                    DeliveryPeriod = 2,
                    SupplierId = 1,
                    MinimumStock = 25,
                    ObjectState = ObjectState.Added
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "bread",
                    Price = new decimal(2.00),
                    DeliveryPeriod = 1,
                    SupplierId = 2,
                    MinimumStock = 60,
                    ObjectState = ObjectState.Added
                }
            );
        }
    }
}
