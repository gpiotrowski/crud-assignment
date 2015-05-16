using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
using CrudAssignment.Service;
using CrudAssignment.Test.Fake;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace CrudAssignment.Test
{
    public static class UnityContainerCreator
    {
        public static UnityContainer CreateUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUnitOfWorkAsync, UnitOfWork>();
            unityContainer.RegisterType<IDataContextAsync, CrudAssignmentFakeContext>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<IRepository<Product>, Repository<Product>>();
            unityContainer.RegisterType<IRepositoryAsync<Product>, Repository<Product>>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<IRepository<Category>, Repository<Category>>();
            unityContainer.RegisterType<IRepositoryAsync<Category>, Repository<Category>>();
            unityContainer.RegisterType<ISupplierService, SupplierService>();
            unityContainer.RegisterType<IRepository<Supplier>, Repository<Supplier>>();
            unityContainer.RegisterType<IRepositoryAsync<Supplier>, Repository<Supplier>>();
            return unityContainer;
        }
    }
}
