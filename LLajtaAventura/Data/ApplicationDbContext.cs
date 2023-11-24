using LLajtaAventura.Models;
using Microsoft.EntityFrameworkCore;

namespace LLajtaAventura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Erased> Erased { get; set; }
        public DbSet<EventCategory> EventCategory { get; set; }
        public DbSet<UserEvent> UserEvent { get; set; }

    }
}
