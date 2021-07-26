using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Life;
using UtopiaCity.Models.CityAdministration;
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

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        
        public DbSet<SportComplex> SportComplex { get; set; }
        
        public DbSet<RersidentAccount> RersidentAccount { get; set; }
        
        public DbSet<Flight> Flights { get; set; }
        
        public DbSet<WeatherReport> WeatherReports { get; set; }

        public DbSet<TimelineModel> TimelineModel { get; set; }

        public DbSet<PermitedModel> PermitedModel { get; set; }

        public DbSet<ScheduleModel> ScheduleModel { get; set; }

        public DbSet<Event> Events { get; set; }
    }
}
