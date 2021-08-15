using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class VacancyInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Vacancies.Any())
            {
                return;
            }

            context.RemoveRange(context.Vacancies.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Vacancies.Any())
            {
                return;
            }

            var vacancy1 = new Vacancy
            {
                Id = "1",
                ProfessionId = "1",
                Salary = 407000,
                Requirement = "Some text",
                Discription = "Discription text",
                CompanyId = "1"
            };

            var vacancy2 = new Vacancy
            {
                Id = "2",
                ProfessionId = "3",
                Salary = 401000,
                Requirement = "Some text",
                Discription = "Discription text",
                CompanyId = "2"
            };

            var vacancy3 = new Vacancy
            {
                Id = "3",
                ProfessionId = "3",
                Salary = 412000,
                Requirement = "Some text",
                Discription = "Discription text",
                CompanyId = "1"
            };

            context.AddRange(vacancy1, vacancy2, vacancy3);
            context.SaveChanges();
        }
    }
}
