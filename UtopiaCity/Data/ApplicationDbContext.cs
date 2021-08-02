using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Life;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportEvent>()
                .HasOne(s => s.SportComplex)
                .WithMany(s => s.SportEvents);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<SportComplex> SportComplex { get; set; }
        public DbSet<SportEvent> SportEvent { get; set; }
        public DbSet<RersidentAccount> RersidentAccount { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
