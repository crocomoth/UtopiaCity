using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class ResumeInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Resumes.Any())
            {
                return;
            }

            context.RemoveRange(context.Resumes.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Resumes.Any())
            {
                return;
            }

            var user1 = context.ResidentAccount.Where(x => x.FirstName == "Marina").FirstOrDefault();
            var resume1 = new Resume
            {

                Id = "1",
                ResidentAccountId = user1.Id,
                ProfessionId = "1",
                Salary = 412000,
                WorkExperienceDateStart = new DateTime(2019, 07, 20),
                WorkExperienceDateEnd = new DateTime(2021, 08, 20),
                UntilNow = false
            };

            var user2 = context.ResidentAccount.Where(x => x.FirstName == "Konstantin").FirstOrDefault();
            var resume2 = new Resume
            {
                Id = "2",
                ResidentAccountId = user2.Id,
                ProfessionId = "2",
                Salary = 408000,
                WorkExperienceDateStart = new DateTime(2018, 04, 18),
                WorkExperienceDateEnd = new DateTime(2021, 07, 21),
                UntilNow = false
            };

            context.AddRange(resume1, resume2);
            context.SaveChanges();
        }
    }
}
