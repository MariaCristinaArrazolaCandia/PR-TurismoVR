using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RolId { get; set; }
        public int? PersonId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }

        public virtual Person? Person { get; set; }
        public virtual Rol Rol { get; set; } = null!;
    }
}
