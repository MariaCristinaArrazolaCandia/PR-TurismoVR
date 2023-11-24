using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class TouristSite
    {
        public TouristSite()
        {
            Horaries = new HashSet<Horary>();
            PhotoTouristSites = new HashSet<PhotoTouristSite>();
        }

        public int TouristSiteId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Horary> Horaries { get; set; }
        public virtual ICollection<PhotoTouristSite> PhotoTouristSites { get; set; }
    }
}
