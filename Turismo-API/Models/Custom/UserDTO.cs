using System.ComponentModel.DataAnnotations;

namespace Turismo_API.Models.Custom
{
    public class UserDTO
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ci { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string State { get; set; } = "";
        public string Email { get; set; }

        public string UserName { get; set; } = "";
        public string Rol { get; set; }
        public string Password { get; set; } = "";
    }
}
