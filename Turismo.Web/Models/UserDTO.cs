using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.InteropServices;
using Turismo.Web.db;

namespace Turismo.Web.Models
{
    public class UserDTO
    {
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Ci { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        public string State { get; set; } = "";
        [Required(ErrorMessage = "El Correo es requerido.")]
        public string Email { get; set; }

        public string UserName { get; set; } = "";
        [Required]
        public string Rol { get; set; } = "X";
        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = "123";
    }
}