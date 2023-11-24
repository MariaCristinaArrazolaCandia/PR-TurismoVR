using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLajtaAventura.Models
{

    [PrimaryKey("IdUser", "IdEvent")]
    public class UserEvent
    {
        [ForeignKey("User")]
        public int IdUser { get; set; }

        [ForeignKey("Event")]
        public int IdEvent { get; set; }
    }
}
