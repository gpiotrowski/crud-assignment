using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public partial class AspNetRole : Entity
    {
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
