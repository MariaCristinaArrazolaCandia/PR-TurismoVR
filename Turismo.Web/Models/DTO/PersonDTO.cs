using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Turismo.Web.Models.DTO
{
    public class PersonDTO : Person
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public int UserID { get; set; } = 0;
    }
    public partial class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Ci { get; set; } = null!;

        public int Phone { get; set; }

        public string Address { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// M : Male
        /// F : Female
        /// </summary>
        public string Gender { get; set; } = null!;

        /// <summary>
        /// 1: Enable
        /// 0: Disable
        /// </summary>
        public byte State { get; set; }
    }
}
