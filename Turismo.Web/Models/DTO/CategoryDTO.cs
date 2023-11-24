using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime RegisterDate { get; set; }

        public DateTime? LastUpdate { get; set; }

        public string Status { get; set; } = null!;
    }
}
