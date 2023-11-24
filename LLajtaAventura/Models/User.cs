using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LLajtaAventura.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [Comment("a=Admin; n=normal")]
        public char Role { get; set; }
    }
}
