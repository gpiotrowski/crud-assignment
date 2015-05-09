using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAssignment.Entities.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DeliveryPeriod { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
