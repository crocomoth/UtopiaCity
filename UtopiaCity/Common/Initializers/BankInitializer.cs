using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Common.Initializers
{
    public class BankInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Banks.Any())
            {
                return;
            }

            context.RemoveRange(context.Banks.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Banks.Any())
            {
                return;
            }

            var bank1 = new Bank
            {
                Id = "1",
                Name = "Al-Hilal bank",
                BIK = "HLALKZKZ"
            };

            var bank2 = new Bank
            {
                Id = "2",
                Name = "Kaspi bank",
                BIK = "KASPKZKZ"
            };

            var bank3 = new Bank
            {
                Id = "3",
                Name = "Halyk bank",
                BIK = "HALKKZKZ"
            };

            context.AddRange(bank1, bank2, bank3);
            context.SaveChanges();
        }
    }
}
