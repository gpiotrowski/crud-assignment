using System;
using System.Data.Common;
using System.Data.Entity;
using CrudAssignment.Entities.Models;
using CrudAssignment.Service;
using CrudAssignment.Web.Controllers;
using CrudAssignment.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace CrudAssignment.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            //ASP.NET Membership
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDataContextAsync, CrudAssignmentContext>(new PerRequestLifetimeManager());
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IRepositoryAsync<Product>, Repository<Product>>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRepositoryAsync<Category>, Repository<Category>>();
            container.RegisterType<ISupplierService, SupplierService>();
            container.RegisterType<IRepositoryAsync<Supplier>, Repository<Supplier>>();
        }
    }
}
