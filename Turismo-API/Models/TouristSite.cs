using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Turismo_API.Models;

[Table("TouristSite")]
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

    [ForeignKey("CategoryId")]
    [InverseProperty("TouristSites")]
    public virtual Category? Category { get; set; }

    [InverseProperty("TouristSite")]
    public virtual ICollection<Horary>? Horaries { get; set; } = new List<Horary>();

    [InverseProperty("TouristSite")]
    public virtual ICollection<PhotoTouristSite>? PhotoTouristSites { get; set; } = new List<PhotoTouristSite>();

    public TouristSite(int touristSiteId, string name, string address, string description, string phoneNumber, string email, DateTime registerDate, DateTime? lastUpdate, string status, string longitude, string latitude, int? categoryId)
    {
        TouristSiteId = touristSiteId;
        Name = name;
        Address = address;
        Description = description;
        PhoneNumber = phoneNumber;
        Email = email;
        RegisterDate = registerDate;
        LastUpdate = lastUpdate;
        Status = status;
        Longitude = longitude;
        Latitude = latitude;
        CategoryId = categoryId;
    }
}
