using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class Person
    {
        public Person()
        {
            Users = new HashSet<User>();
        }

        public int PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? SecondLastname { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HomeAddress { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public byte Status { get; set; }
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
