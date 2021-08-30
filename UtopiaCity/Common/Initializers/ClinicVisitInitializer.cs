using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Clinic;

namespace UtopiaCity.Common.Initializers
{
    public class ClinicVisitInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.ClinicVisit.Any())
            {
                return;
            }

            context.RemoveRange(context.ClinicVisit.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.ClinicVisit.Any())
            {
                return;
            }

            var visit1 = new ClinicVisit
            {
                Visit = "Visit 1",
                VisitTime = DateTime.Now
            };

            var visit2 = new ClinicVisit
            {
                Visit = "Visit 2",
                VisitTime = DateTime.Now
            };

            var visit3 = new ClinicVisit
            {
                Visit = "Visit 3",
                VisitTime = DateTime.Now
            };

            context.AddRange(visit1, visit2, visit3);
            context.SaveChanges();
        }
    }
}
