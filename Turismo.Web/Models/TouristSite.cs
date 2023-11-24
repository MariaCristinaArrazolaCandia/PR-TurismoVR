using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public class TouristSite
    {
        [Key]
        public int TouristSiteId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Description { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(60)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Status { get; set; } = "1";

        [StringLength(20)]
        [Unicode(false)]
        public string Longitude { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string Latitude { get; set; } = null!;

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Horary>? Horaries { get; set; } = new List<Horary>();

        /*using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models.DTO
{
    public class TouristSiteDTO : TouristSite
    {
        public List<Horary>? Horaries { get; set; }
        public List<string>? Images { get; set; }
    }
    public partial class TouristSite
    {
        [Key]
        public int TouristSiteId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Address { get; set; } = null!;

        [StringLength(100)]
        [Unicode(false)]
        public string Description { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(60)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Status { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string Longitude { get; set; } = null!;

        [StringLength(20)]
        [Unicode(false)]
        public string Latitude { get; set; } = null!;

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Horary>? Horaries { get; set; } = new List<Horary>();

    }

    public partial class Horary
    {
        [Key]
        public int HoraryId { get; set; }
        public string OpeningHour { get; set; } = null!;
        public string ClosingHour { get; set; } = null!;
        public string OpeningDays { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public byte Status { get; set; }
        public int TouristSiteId { get; set; }
        public virtual TouristSite? TouristSite { get; set; } = null!;
    }
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public virtual ICollection<TouristSite>? TouristSites { get; set; } = new List<TouristSite>();
    }
}
*/
    }
}
