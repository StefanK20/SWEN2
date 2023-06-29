using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TourPlanner.Models;

namespace TourPlanner.DAL.SQL
{
    public class TourPlannerContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build the configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("Config/settings.json")
                .Build();

            // Get the database configuration section
            var dbConfig = config.GetSection("db");

            // Retrieve the connection string values from the config
            var host = dbConfig["host"];
            var port = dbConfig["port"];
            var username = dbConfig["username"];
            var password = dbConfig["password"];
            var database = dbConfig["database"];

            // Set the connection string and configure the database provider
            optionsBuilder.UseNpgsql($"Host={host};Port={port};Database={database};Username={username};Password={password}");
        }
    }
}
