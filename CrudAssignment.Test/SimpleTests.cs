﻿using System.Linq;
using CrudAssignment.Entities.Models;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace CrudAssignment.Test
{
    [TestClass]
    public class SimpleTests
    {
        private UnityContainer unityContainer;

        [TestInitialize()]
        public void Initialize()
        {
            unityContainer = UnityContainerCreator.CreateUnityContainer();
        }

        [TestMethod]
        public void ProductInsertTest()
        {
            // Arrange
            var productService = unityContainer.Resolve<IRepository<Product>>();
            var unitOfWork = unityContainer.Resolve<IUnitOfWorkAsync>();
            productService.Insert(new Product());
            unitOfWork.SaveChanges();

            // Act
            var products = productService.Queryable().ToList();

            // Assert
            Assert.AreEqual(products.Count(), 1);
        }
    }
}
