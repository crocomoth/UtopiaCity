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
                FirstName = "Marina",
                LastName = "Glebova",
                Insurance = "yes",
                DoB = new DateTime(1984, 02, 19),
                PhoneNumber = 87252330133,
                Doctor = "Dentist",
                Visit = "toothache",
                VisitTime = DateTime.Now
            };

            var visit2 = new ClinicVisit
            {
                FirstName = "Kirill",
                LastName = "Boiko",
                Insurance = "yes",
                DoB = new DateTime(1985, 06, 02),
                PhoneNumber = 87272692189,
                Doctor = "GP",
                Visit = "routine examination",
                VisitTime = DateTime.Now
            };

            var visit3 = new ClinicVisit
            {
                FirstName = "Anna",
                LastName = "Borisova",
                Insurance = "yes",
                DoB = new DateTime(1981, 05, 11),
                PhoneNumber = 877242237329,
                Doctor = "Ophthalmologist",
                Visit = "need glasses for work with computer",
                VisitTime = DateTime.Now
            };

            context.AddRange(visit1, visit2, visit3);
            context.SaveChanges();
        }
    }
}
