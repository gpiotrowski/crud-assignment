using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public class Product : Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DeliveryPeriod { get; set; }
        public int MinimumStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
