using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Common.Initializers
{
    public class DepartmentStatusInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.DepartmentStatuses.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.DepartmentStatuses.Any())
            {
                return;
            }

            var status1 = new DepartmentStatus
            {
                Name = "Free"
            };
            var status2 = new DepartmentStatus
            {
                Name = "Busy"
            };
            var status3 = new DepartmentStatus
            {
                Name = "On the road"
            };

            context.AddRange(status1, status2, status3);
            context.SaveChanges();
        }
    }
}
