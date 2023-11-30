﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo_API.Models.Custom
{
    public class TouristSiteDataDTO
    {
        public int TouristSiteId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime RegisterDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Status { get; set; } = null!;
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string Category { get; set; } = "";
        public List<string> Imagenes { get; set; }
    }
}