using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LLajtaAventura.Models
{
    [PrimaryKey("IdEvent", "IdCategory")]
    public class EventCategory
    {
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        [ForeignKey("Category")]
        public int IdCategory { get; set; }

    }


}
