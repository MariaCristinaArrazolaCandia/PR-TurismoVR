using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public partial class Horary
    {
        [Key]
        public int HoraryId { get; set; }

        [StringLength(6)]
        [Unicode(false)]
        public string OpeningHour { get; set; } = null!;

        [StringLength(6)]
        [Unicode(false)]
        public string ClosingHour { get; set; } = null!;

        [StringLength(15)]
        [Unicode(false)]
        public string OpeningDays { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        public byte Status { get; set; }

        public int TouristSiteId { get; set; }

        [ForeignKey("TouristSiteId")]
        [InverseProperty("Horaries")]
        public virtual TouristSite? TouristSite { get; set; } = null!;
    }

}
