using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLajtaAventura.Models
{
    public class Erased
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Reason { get; set; }
        [Required]
        public bool Seen { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

    }
}
