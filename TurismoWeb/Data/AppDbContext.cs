namespace TurismoWeb.Data
{
    using Microsoft.EntityFrameworkCore;
    using TurismoWeb.Models;

    public class AppDbContext : DbContext
    {
        public DbSet<TouristAttraction> TouristAttractions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

