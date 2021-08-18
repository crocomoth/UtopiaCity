using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class ProfessionInitializer: ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Professions.Any())
            {
                return;
            }
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Professions.Any())
            {
                return;
            }

            var profession1 = new Profession
            {
                Id = "1",
                Name = "Programmer C#"
            };

            var profession2 = new Profession
            {
                Id = "2",
                Name = "Teacher"
            };

            var profession3 = new Profession
            {
                Id = "3",
                Name = "engineer"
            };

            var profession4 = new Profession
            {
                Id = "4",
                Name = "Manager"
            };

            context.AddRange(profession1, profession2, profession3, profession4);
            context.SaveChanges();
        }
    }
}
