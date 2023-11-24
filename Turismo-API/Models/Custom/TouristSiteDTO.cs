namespace Turismo_API.Models.Custom
{
    public class TouristSiteDTO : TouristSite
    {
        public List<Horary>? Horaries { get; set; }
        public List<string>? Images { get; set; }
        public TouristSiteDTO(int touristSiteId, string name, string address, string description, string phoneNumber, string email, DateTime registerDate, DateTime? lastUpdate, string status, string longitude, string latitude, int? categoryId, List<Horary> horaries, List<string> images) : base(touristSiteId, name, address, description, phoneNumber, email, registerDate, lastUpdate, status, longitude, latitude, categoryId)
        {
            Horaries = horaries;
            Images = images;
        }
    }
}
