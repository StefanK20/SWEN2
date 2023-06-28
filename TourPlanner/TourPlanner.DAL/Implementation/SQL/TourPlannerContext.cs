using Microsoft.EntityFrameworkCore;
using TourPlanner.Models;
using Npgsql;

namespace TourPlanner.DAL.SQL
{
    public class TourPlannerContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the connection string and configure the database provider
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tourplanner;Username=postgres;Password=postgres");
        }
    }
}