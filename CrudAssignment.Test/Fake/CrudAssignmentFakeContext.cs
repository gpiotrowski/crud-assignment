using CrudAssignment.Entities.Models;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Test.Fake
{
    public class CrudAssignmentFakeContext : FakeDbContext
    {
        public CrudAssignmentFakeContext()
        {
            AddFakeDbSet<Category, CategoryDbSet>();
            AddFakeDbSet<Supplier, SupplierDbSet>();
            AddFakeDbSet<Product, ProductDbSet>();
        }
    }
}
