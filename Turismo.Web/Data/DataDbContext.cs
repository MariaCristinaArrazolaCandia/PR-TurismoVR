using Microsoft.EntityFrameworkCore;
using Turismo.Web.Data;
using Turismo.Web.Models;

namespace Turismo.Web.Data
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
    
        //public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TouristSite> touristSiteDTOs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Person>().ToTable("Person");


            base.OnModelCreating(modelBuilder);
        }
    }
}
