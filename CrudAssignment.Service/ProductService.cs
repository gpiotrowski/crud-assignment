using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
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
    }
}
