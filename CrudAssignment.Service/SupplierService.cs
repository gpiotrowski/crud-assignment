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
    public interface ISupplierService : IService<Supplier>
    {
    }

    public class SupplierService : Service<Supplier>, ISupplierService
    {
        private readonly IRepositoryAsync<Supplier> _sypplierRepository;

        public SupplierService(IRepositoryAsync<Supplier> supplierRepository) : base(supplierRepository)
        {
            _sypplierRepository = supplierRepository;
        }
    }
}
