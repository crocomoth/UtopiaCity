using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Common.Initializers
{
    public class TransportManagementInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.TransportsManagement.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.TransportsManagement.Any())
            {
                return;
            }

            var transports = new List<TransportManagement>()
            {
                new TransportManagement()
                {
                    TypeOfFireCar = "тип 1",
                    DepartmentName = "Отдел пожарной безопасности №1",
                    FirePump = true,
                    ContainerForStoringFireExtinguishingAgents = true,
                    FireFightingEquipment = "снаряжение 1",
                },

                new TransportManagement()
                {
                    TypeOfFireCar = "тип 2",
                    DepartmentName = "Отдел пожарной безопасности №2",
                    FirePump = true,
                    ContainerForStoringFireExtinguishingAgents = false,
                    FireFightingEquipment = "снаряжение 2",
                },

                new TransportManagement()
                {
                    TypeOfFireCar = "тип 3",
                    DepartmentName = "Отдел пожарной безопасности №3",
                    FirePump = false,
                    ContainerForStoringFireExtinguishingAgents = false,
                    FireFightingEquipment = "снаряжение 3",
                }
            };

            var departments = context.Departments.ToList();
            for(int i = 0; i < transports.Count; i++)
            {
                var department = departments.FirstOrDefault(x => transports[i].DepartmentName
                .Contains(x.Name, StringComparison.InvariantCultureIgnoreCase));
                if (department == null)
                {
                    transports.RemoveAt(i--);
                }
                else
                {
                    transports[i].Department = department;
                }
            }

            context.AddRange(transports);
            context.SaveChanges();
        }
    }
}
