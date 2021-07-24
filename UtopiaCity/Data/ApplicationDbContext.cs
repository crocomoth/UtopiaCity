using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Sport;

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
        public DbSet<Flight> Flights { get; set; }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<EmergencyCertificate> EmergencyCertificate { get; set; }
    }
}
