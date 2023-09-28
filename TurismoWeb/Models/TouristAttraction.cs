namespace TurismoWeb.Models
{
    using System;

    public class TouristAttraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        // Other properties

        public Category Category { get; set; } // Navigation property
    }
}
