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
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Delivery period")]
        [Range(0, int.MaxValue)]
        public int DeliveryPeriod { get; set; }
        [Required]
        [DisplayName("Minimum stock")]
        [Range(0, int.MaxValue)]
        public int MinimumStock { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
