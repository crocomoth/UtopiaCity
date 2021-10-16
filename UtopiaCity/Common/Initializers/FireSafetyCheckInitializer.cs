using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Common.Initializers
{
    public class FireSafetyCheckInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.FireSafetyCheck.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.FireSafetyCheck.Any())
            {
                return;
            }

            //var check1 = new FireSafetyCheck
            //{
            //    Id = "1",
            //    Address = "address 1",
            //    ObjectName = "name 1",
            //    FireSafetyDocuments = true,
            //    FireFightingEquipment = true,
            //    Journals = true,
            //    FireSafetySigns = true,
            //    EscapeRoutes = true,
            //    SmokingAreas = true,
            //    EmployeeId = "1"
            //};
            //var check2 = new FireSafetyCheck
            //{
            //    Id = "2",
            //    Address = "address 2",
            //    ObjectName = "name 2",
            //    FireSafetyDocuments = true,
            //    FireFightingEquipment = false,
            //    Journals = true,
            //    FireSafetySigns = false,
            //    EscapeRoutes = true,
            //    SmokingAreas = false,
            //    EmployeeId = "2"
            //};
            //var check3 = new FireSafetyCheck
            //{
            //    Id = "3",
            //    Address = "address 3",
            //    ObjectName = "name 3",
            //    FireSafetyDocuments = true,
            //    FireFightingEquipment = true,
            //    Journals = true,
            //    FireSafetySigns = false,
            //    EscapeRoutes = false,
            //    SmokingAreas = false,
            //    EmployeeId = "3"
            //};

            //context.AddRange(check1, check2, check3);
            //context.SaveChanges();
        }
    }
}
