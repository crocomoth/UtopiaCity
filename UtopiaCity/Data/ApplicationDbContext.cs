using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmergencyReport> EmergencyReport { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
