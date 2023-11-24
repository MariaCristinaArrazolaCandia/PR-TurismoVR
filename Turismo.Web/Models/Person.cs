using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(60)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(35)]
        public string? Lastname { get; set; }

        [MaxLength(35)]
        public string? SecondLastname { get; set; }

        [Required]
        [MaxLength(15)]
        public string? IdentityNumber { get; set; }

        [MaxLength(20)]
        public string? Telephone { get; set; }

        [MaxLength(60)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? HomeAddress { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        [StringLength(5)]
        public string? Gender { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public DateTime LastUpdate { get; set; }

        public byte Status { get; set; }

        [Required]
        public int UserRegister { get; set; }

        [Required]
        public int UserLastUpdate { get; set; }
        public int RolId { get; set; }
        public User? User { get; set; }
    }
}
