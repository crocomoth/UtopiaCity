using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

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

            var departments = new FireSafetyDepartment[]
            {
                new FireSafetyDepartment
                {
                    Name = "Отдел пожарной безопасности №1",
                    Сhief = "Иванов Иван Иванович",
                    DepartmentStatusEnum = DepartmentStatusEnum.Free
                },

                new FireSafetyDepartment
                {
                    Name = "Отдел пожарной безопасности №2",
                    Сhief = "Данилов Сергей Иванович",
                    DepartmentStatusEnum = DepartmentStatusEnum.OnTheRoad
                },

                new FireSafetyDepartment
                {
                    Name = "Отдел пожарной безопасности №3",
                    Сhief = "Кириллов Александ Иванович",
                    DepartmentStatusEnum = DepartmentStatusEnum.Free
                }
            };

            context.AddRange(departments);
            context.SaveChanges();
        }
    }
}
