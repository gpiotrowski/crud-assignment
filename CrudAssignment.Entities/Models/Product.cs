using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public class Product : Entity
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Product name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Delivery period")]
        public int DeliveryPeriod { get; set; }
        [Required]
        [DisplayName("Minimum stock")]
        public int MinimumStock { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
