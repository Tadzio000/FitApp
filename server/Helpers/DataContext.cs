using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=admin;Database=postgres;");
            optionsBuilder.UseNpgsql("Host=fitdb.clbfkbqft4wd.eu-west-1.rds.amazonaws.com;Port=5432;Username=postgres;Password=postgres;Database=fitDB;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
                .HasMany(b => b.Exercises)
                .WithOne();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}