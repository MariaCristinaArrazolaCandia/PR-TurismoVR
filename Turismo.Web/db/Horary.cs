using System;
using System.Collections.Generic;

namespace Turismo.Web.db
{
    public partial class Horary
    {
        public int HoraryId { get; set; }
        public TimeSpan OpeningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
        public string DpeningDays { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public byte Status { get; set; }
        public int? UserRegister { get; set; }
        public int? UserLastUpdate { get; set; }
        public int TouristSiteId { get; set; }

        public virtual TouristSite TouristSite { get; set; } = null!;
    }
}
