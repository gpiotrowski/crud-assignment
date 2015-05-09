using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public class Supplier : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}