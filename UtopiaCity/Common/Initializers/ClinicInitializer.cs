using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Clinic;

namespace UtopiaCity.Common.Initializers
{
    public class ClinicInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.ClinicReport.Any())
            {
                return;
            }

            context.RemoveRange(context.ClinicReport.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.ClinicReport.Any())
            {
                return;
            }

            var clinicreport1 = new ClinicReport
            {
                Report = "Report 1",
                ReportTime = DateTime.Now
            };

            var clinicreport2 = new ClinicReport
            {
                Report = "Report 2",
                ReportTime = DateTime.Now
            };

            var clinicreport3 = new ClinicReport
            {
                Report = "Report 3",
                ReportTime = DateTime.Now
            };

            context.AddRange(clinicreport1, clinicreport2, clinicreport3);
            context.SaveChanges();
        }
    }
}
