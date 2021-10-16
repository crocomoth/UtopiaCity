using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Common.Initializers
{
    public class DepatureToThePlaceInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.DeparturesToThePlaces.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.DeparturesToThePlaces.Any())
            {
                return;
            }

            var depatures = new List<DepartureToThePlaceOfFire>()
            {
                new DepartureToThePlaceOfFire()
                {
                    Address = "Address 1",
                    FullName = "ФИО 1",
                    PhoneNumber = "87475635685",
                    DepartmentName = "Отдел пожарной безопасности №1"
                },

                new DepartureToThePlaceOfFire()
                {
                    Address = "Address 2",
                    FullName = "ФИО 1",
                    PhoneNumber = "87475635685",
                    DepartmentName = "Отдел пожарной безопасности №2"
                },

                new DepartureToThePlaceOfFire()
                {
                    Address = "Address 3",
                    FullName = "ФИО 1",
                    PhoneNumber = "87475635685",
                    DepartmentName = "Отдел пожарной безопасности №3"
                },
            };

            var departments = context.Departments.ToList();
            for (int i = 0; i < departments.Count; i++)
            {
                var department = departments.FirstOrDefault(x => depatures[i].DepartmentName
                .Equals(x.Name, StringComparison.InvariantCultureIgnoreCase));
                depatures[i].Department = department;
            }

            var messages = context.FireMessage.ToList();
            for (int i = 0; i < messages.Count; i++)
            {
                var message = messages.FirstOrDefault(x => depatures[i].Address
                .Equals(x.Address, StringComparison.InvariantCultureIgnoreCase));
                depatures[i].FireMessage = message;
            }

            context.AddRange(depatures);
            context.SaveChanges();
        }
    }
}
