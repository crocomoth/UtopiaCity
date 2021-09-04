using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Business;
using UtopiaCity.Models.Airport.TransportManagerSystem;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Life;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.Sport;
using UtopiaCity.Models.TimelineModel;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.Clinic;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

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

            modelBuilder.Entity<SportTicket>()
                .HasOne(s => s.SportComplex)
                .WithMany(t => t.SportTickets)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SportTicket>()
                .HasOne(s => s.SportEvent)
                .WithMany(s => s.SportTickets)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SportTicket>()
                .HasOne(r => r.AppUser)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestToAdministration>()
                .HasOne(s => s.SportComplex)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmergencyCertificate> EmergencyCertificate { get; set; }
        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<SportComplex> SportComplex { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<ForPassenger> ForPassengers { get; set; }
        public DbSet<ForCompany> ForCompanies { get; set; }
        public DbSet<TransportManager> TransportManagers { get; set; }       
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ResidentAccount> ResidentAccount { get; set; }
        public DbSet<TimelineModel> TimelineModel { get; set; }
        public DbSet<ScheduleModel> ScheduleModel { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CompanyStatus> CompanyStatuses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<CitizensTask> CitizensTasks { get; set; }
        public DbSet<Marriage> Marriage { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<SportTicket> SportTickets { get; set; }
        public DbSet<RequestToAdministration> RequestsToAdministration { get; set; }
        public DbSet<PermitedModel> PermitedModel { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<ArrivingPassenger> ArrivingPassengers { get; set; }
        public DbSet<ClinicVisit> ClinicVisit { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<RealEstate> RealEstate { get; set; }
        public DbSet<FireMessage> FireMessage { get; set; }
        public DbSet<FireSafetyCheck> FireSafetyCheck { get; set; }
        public DbSet<TransportManagement> TransportsManagement { get; set; }
        public DbSet<EmployeeManagement> EmployeesManagement { get; set; }
    }
}
