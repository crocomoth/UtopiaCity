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

            var employees = new List<EmployeeManagement>()
            {
                new EmployeeManagement()
                {
                    FullName = "ФИО 1",
                    PhoneNumber = "87475685685",
                    //Equipment = "снаряжение 1",
                    CanCheck = true,
                    DepartmentName = "Отдел пожарной безопасности №1",
                    EmployeePosition = "должность 1"
                },

                new EmployeeManagement()
                {
                    FullName = "ФИО 2",
                    PhoneNumber = "87475635685",
                    //Equipment = "снаряжение 2",
                    CanCheck = true,
                    DepartmentName = "Отдел пожарной безопасности №2",
                    EmployeePosition = "должность 2"
                },

                new EmployeeManagement()
                {
                    FullName = "ФИО 3",
                    PhoneNumber = "87475635655",
                    //Equipment = "снаряжение 3",
                    CanCheck = false,
                    DepartmentName = "Отдел пожарной безопасности №3",
                    EmployeePosition = "должность 3"
                }
            };

            var departments = context.Departments.ToList();
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments.FirstOrDefault(x => employees[i].DepartmentName
                .Contains(x.Name, StringComparison.InvariantCultureIgnoreCase));
                if (department == null)
                {
                    employees.RemoveAt(i--);
                }
                else
                {
                    employees[i].Department = department;
                }
            }

            var positions = context.Positions.ToList();
            for (int i = 0; i < positions.Count; i++)
            {
                var position = positions.FirstOrDefault(x => employees[i].EmployeePosition
                .Contains(x.Name, StringComparison.InvariantCultureIgnoreCase));
                if (position == null)
                {
                    employees.RemoveAt(i--);
                }
                else
                {
                    employees[i].Position = position;
                }
            }


            context.AddRange(employees);
            context.SaveChanges();
        }
    }
}
