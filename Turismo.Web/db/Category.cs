using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class Category
    {
        public Category()
        {
            TouristSites = new HashSet<TouristSite>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }

        public virtual ICollection<TouristSite> TouristSites { get; set; }
    }
}
