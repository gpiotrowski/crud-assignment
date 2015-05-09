using System.Collections;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public class Supplier : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}