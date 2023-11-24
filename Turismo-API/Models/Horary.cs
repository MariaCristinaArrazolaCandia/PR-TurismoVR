using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Turismo_API.Models;

[Table("Horary")]
public partial class Horary
{
    [Key]
    public int HoraryId { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string OpeningHour { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string ClosingHour { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string OpeningDays { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RegisterDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastUpdate { get; set; }

    public byte Status { get; set; }

    public int TouristSiteId { get; set; }

    [ForeignKey("TouristSiteId")]
    [InverseProperty("Horaries")]
    public virtual TouristSite? TouristSite { get; set; } = null!;
}
