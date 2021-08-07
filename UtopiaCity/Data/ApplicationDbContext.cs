using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Airport.TransportManagerSystem;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Life;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.TimelineModel;

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
                .WithMany(e => e.SportEvents)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<RersidentAccount> RersidentAccount { get; set; }
        public DbSet<SportComplex> SportComplexes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PermitedModel> PermitedModel { get; set; }
        public DbSet<ScheduleModel> ScheduleModel { get; set; }
        public DbSet<TimelineModel> TimelineModel { get; set; }
        public DbSet<ForPassenger> ForPassengers { get; set; }
        public DbSet<TransportManager> TransportManagers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }
    }
}
