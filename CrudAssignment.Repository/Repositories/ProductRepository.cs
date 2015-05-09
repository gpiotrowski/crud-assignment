using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
using Repository.Pattern.Repositories;

namespace CrudAssignment.Repository.Repositories
{
    public static class ProductRepository
    {
        public static IEnumerable<Product> GetProductsOrderByName(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.Name);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.Name);
            }
        }

        public static IEnumerable<Product> GetProductsOrderByCategory(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.Category);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.Category);
            }
        }

        public static IEnumerable<Product> GetProductsOrderBySupplier(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.Supplier);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.Supplier);
            }
        }

        public static IEnumerable<Product> GetProductsOrderByPrice(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.Price);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.Price);
            }
        }

        public static IEnumerable<Product> GetProductsOrderByDeliveryPeriod(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.DeliveryPeriod);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.DeliveryPeriod);
            }
        }

        public static IEnumerable<Product> GetProductsOrderByMinimumStock(this IRepositoryAsync<Product> repository, bool ascending = true)
        {
            if (ascending)
            {
                return repository.Queryable().OrderBy(p => p.MinimumStock);
            }
            else
            {
                return repository.Queryable().OrderByDescending(p => p.MinimumStock);
            }
        }
    }
}
