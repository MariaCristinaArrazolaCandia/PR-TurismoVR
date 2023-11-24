using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class PhotoTouristSite
    {
        public int PhotoTouristSiteId { get; set; }
        public byte[] Photo { get; set; } = null!;
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public int TouristSiteId { get; set; }

        public virtual TouristSite TouristSite { get; set; } = null!;
    }
}
