using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        [MaxLength(35)]
        public string? Name { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; }
        //public User? User { get; set; }
    }
}
