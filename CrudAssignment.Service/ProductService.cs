using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
using CrudAssignment.Repository.Repositories;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace CrudAssignment.Service
{
    public interface IProductService : IService<Product>
    {
    }

    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepositoryAsync<Product> _productRepository;

        public ProductService(IRepositoryAsync<Product> productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductsOrderByName(bool ascending = true)
        {
            return _productRepository.GetProductsOrderByName(ascending);
        }

        public IEnumerable<Product> GetProductsOrderByCategory(bool ascending = true)
        {
            return _productRepository.GetProductsOrderByCategory(ascending);
        }

        public IEnumerable<Product> GetProductsOrderBySupplier(bool ascenging = true)
        {
            return _productRepository.GetProductsOrderBySupplier(ascenging);
        }

        public IEnumerable<Product> GetProductsOrderByPrice(bool ascending = true)
        {
            return _productRepository.GetProductsOrderByPrice(ascending);
        }

        public IEnumerable<Product> GetProductsOrderByDeliveryPeriod(bool ascending = true)
        {
            return _productRepository.GetProductsOrderByDeliveryPeriod(ascending);
        }

        public IEnumerable<Product> GetProductsOrderByMinimumStock(bool ascending = true)
        {
            return _productRepository.GetProductsOrderByMinimumStock(ascending);
        }
    }
}
