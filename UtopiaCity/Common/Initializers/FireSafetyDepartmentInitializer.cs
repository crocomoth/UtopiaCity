using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Common.Initializers
{
    public class FireSafetyDepartmentInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Departments.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Departments.Any())
            {
                return;
            }

            var department1 = new FireSafetyDepartment
            {
                Name = "отдел 1",
                Сhief = "руководитель 1",
                DepartmentStatusId = "1"
            };
            var department2 = new FireSafetyDepartment
            {
                Name = "отдел 2",
                Сhief = "руководитель 2",
                DepartmentStatusId = "2"
            };
            var department3 = new FireSafetyDepartment
            {
                Name = "отдел 3",
                Сhief = "руководитель 3",
                DepartmentStatusId = "3"
            };

            context.AddRange(department1, department2, department3);
            context.SaveChanges();
        }
    }
}
