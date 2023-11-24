using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime RegisterDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Status { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<TouristSite>? TouristSites { get; set; } = new List<TouristSite>();
    }

}
