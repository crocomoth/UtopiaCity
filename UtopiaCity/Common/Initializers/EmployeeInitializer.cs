using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class EmployeeInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            var employee1 = new Employee
            {
                Id = "1",
                FIO = "Abaev Azamat",
                ProfessionId = "1",
                Salary = 450000,
                CompanyId = "1"
            };

            var employee2 = new Employee
            {
                Id = "2",
                FIO = "Adilova Dana",
                ProfessionId = "3",
                Salary = 412000,
                CompanyId = "2"
            };

            var employee3 = new Employee
            {
                Id = "3",
                FIO = "Galimov Gibrat",
                ProfessionId = "3",
                Salary = 405000,
                CompanyId = "1"
            };

            context.AddRange(employee1, employee2, employee3);
            context.SaveChanges();
        }
    }
}
