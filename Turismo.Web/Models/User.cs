using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(35)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Password { get; set; }

        public int RolId { get; set; }

        public int PersonId { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }

        [Required]
        public int UserRegister { get; set; }

        [Required]
        public int UserLastUpdate { get; set; }
      
        public Person? Person { get; set; }
        public Rol? Rol { get; set; }
    }
}
