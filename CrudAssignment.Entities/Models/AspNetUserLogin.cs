using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace CrudAssignment.Entities.Models
{
    public partial class AspNetUserLogin : Entity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
