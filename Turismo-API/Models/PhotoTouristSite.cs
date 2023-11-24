using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Turismo_API.Models;

[Table("PhotoTouristSite")]
public partial class PhotoTouristSite
{
    [Key]
    public int PhotoTouristSiteId { get; set; }

    [Unicode(false)]
    public string Photo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RegisterDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    public int TouristSiteId { get; set; }

    [ForeignKey("TouristSiteId")]
    [InverseProperty("PhotoTouristSites")]
    public virtual TouristSite? TouristSite { get; set; } = null!;
}
