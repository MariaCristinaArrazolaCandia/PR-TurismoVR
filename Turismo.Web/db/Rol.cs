using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        public int RolId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
