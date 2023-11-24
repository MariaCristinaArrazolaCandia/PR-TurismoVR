namespace LLajtaAventura.Models
{
    public class PhotoTouristSiteDTO
    {
    
            public int PhotoTouristSiteId { get; set; }
            public string Photo { get; set; } = null!;
            public DateTime RegisterDate { get; set; }
            public DateTime? LastUpdate { get; set; }
            public string Status { get; set; } = null!;
            public int TouristSiteId { get; set; }
        
    }
}
