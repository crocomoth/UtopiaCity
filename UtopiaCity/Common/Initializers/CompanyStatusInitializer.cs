using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class CompanyStatusInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.CompanyStatuses.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.CompanyStatuses.Any())
            {
                return;
            }

            var status1 = new CompanyStatus
            {
                Id = "1",
                Name = "Open"
            };

            var status2 = new CompanyStatus
            {
                Id = "2",
                Name = "Close"
            };

            var status3 = new CompanyStatus
            {
                Id = "3",
                Name = "Stopped"
            };

            context.AddRange(status1, status2, status3);
            context.SaveChanges();
        }
    }
}
