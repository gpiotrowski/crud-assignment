using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrudAssignment.Entities.Models;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Test.Fake
{
    public class CategoryDbSet : FakeDbSet<Category>
    {
        public override Category Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault());
        }

        public override Task<Category> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Category>(() => Find(keyValues));
        }
    }

    public class SupplierDbSet : FakeDbSet<Supplier>
    {
        public override Supplier Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault());
        }

        public override Task<Supplier> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Supplier>(() => this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault()));
        }
    }

    public class ProductDbSet : FakeDbSet<Product>
    {
        public override Product Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault());
        }

        public override Task<Product> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return new Task<Product>(() => this.SingleOrDefault(t => t.Id == (int) keyValues.FirstOrDefault()));
        }
    }
}