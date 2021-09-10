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

            var transport1 = new TransportManagement
            {
                TypeOfFireCar = "тип 1",
                FirePump = true,
                ContainerForStoringFireExtinguishingAgents = true,
                FireFightingEquipment = "снаряжение 1",
                DepartmentId = "1"
            };

            var transport2 = new TransportManagement
            {
                TypeOfFireCar = "тип 2",
                FirePump = true,
                ContainerForStoringFireExtinguishingAgents = false,
                FireFightingEquipment = "снаряжение 2",
                DepartmentId = "2"
            };

            var transport3 = new TransportManagement
            {
                TypeOfFireCar = "тип 3",
                FirePump = true,
                ContainerForStoringFireExtinguishingAgents = true,
                FireFightingEquipment = "снаряжение 3",
                DepartmentId = "3"
            };

            context.AddRange(transport1, transport2, transport3);
            context.SaveChanges();
        }
    }
}
