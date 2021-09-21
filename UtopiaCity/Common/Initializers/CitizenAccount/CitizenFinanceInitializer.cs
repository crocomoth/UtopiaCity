using System;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.CitizenAccount
{
    public class CitizenFinanceInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Transactions.Any())
            {
                return;
            }

            context.RemoveRange(context.Transactions.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Transactions.Any())
            {
                return;
            }

            var citizenTranzaction = new Transaction
            {
                Amount=150,
                Description = "Top up balance",
                UserId = "1",
                User =(AppUser) context.AppUser.FirstOrDefault(x=>x.UserName == "Jenya@mail.ru"),
                Date = new DateTime(2021, 9, 15),
            };


            var citizenTranzaction1 = new Transaction
            {
                Amount = 427,
                Description = "Top up balance",
                UserId = "1",
                User = (AppUser)context.AppUser.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                Date = new DateTime(2021, 9, 16)
            };


            var citizenTranzaction2 = new Transaction
            {
                Amount = 200,
                Description = "Buy shoots",
                UserId = "1",
                User = (AppUser)context.AppUser.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                Date = new DateTime(2021, 9, 17)
            };

            var citizenTranzaction3 = new Transaction
            {
                Amount = 5,
                Description = "Buy coffee",
                UserId = "1",
                User = (AppUser)context.AppUser.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                Date = new DateTime(2021, 9, 20)
            };

            var citizenTranzaction4 = new Transaction
            {
                Amount = 541,
                Description = "Top up balance",
                UserId = "1",
                User = (AppUser)context.AppUser.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                Date = new DateTime(2021, 9, 22)
            };
            List<Transaction> transactions = new List<Transaction>
            {
                citizenTranzaction,
                citizenTranzaction1,
                citizenTranzaction2,
                citizenTranzaction3,
                citizenTranzaction4
            };
            double amount = 0;
            foreach (var item in transactions)
            {
                if (item.Description== "Top up balance")
                {
                    amount += item.Amount;
                }
                else
                {
                    amount -= item.Amount;
                }
            }

            context.AppUser.FirstOrDefault(x => x.UserName == "Jenya@mail.ru").Balance=amount;
            context.AddRange(citizenTranzaction,citizenTranzaction1,citizenTranzaction2,citizenTranzaction3, citizenTranzaction4);
            context.SaveChanges();
        }
    }
}
