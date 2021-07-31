using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class CompanyInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Companies.Any())
            {
                return;
            }

            context.RemoveRange(context.Companies.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Companies.Any())
            {
                return;
            }

            var company1 = new Company
            {
                Name = "Izi Build",
                CEO = "Aibek",
                IIK = "KZ232465555555555688",
                BIN = "100140011785"
            };

            var company2 = new Company
            {
                Name = "Car wash - OzinZhu",
                CEO = "Baur",
                IIK = "KZ555465555555555654",
                BIN = "450140011788"
            };

            context.AddRange(company1, company2);
            context.SaveChanges();
        }
    }
}
