using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLajtaAventura.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? ImagePath { get; set; }
        [Comment("f=futuro; p=pasado; c=cancelado")]
        public char State { get; set; }
        [Required]
        [ForeignKey("User")]
        public int IdUser { get; set; }

    }
}
