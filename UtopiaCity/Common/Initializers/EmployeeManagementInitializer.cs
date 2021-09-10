using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Common.Initializers
{
    public class EmployeeManagementInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.EmployeesManagement.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.EmployeesManagement.Any())
            {
                return;
            }

            var employee1 = new EmployeeManagement
            {
                FullName = "ФИО 1",
                PhoneNumber = "87475685685",
                Equipment = "снаряжение 1",
                PositionId = "1",
                DepartmentId = "1"
            };

            var employee2 = new EmployeeManagement
            {
                FullName = "ФИО 2",
                PhoneNumber = "87474685685",
                Equipment = "снаряжение 2",
                PositionId = "2",
                DepartmentId = "2"
            };

            var employee3 = new EmployeeManagement
            {
                FullName = "ФИО 3",
                PhoneNumber = "87474485685",
                Equipment = "снаряжение 3",
                PositionId = "3",
                DepartmentId = "3"
            };

            context.AddRange(employee1, employee2, employee3);
            context.SaveChanges();
        }
    }
}
