using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.CitizenAccount
{
    public class CitizenTaskInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.CitizensTasks.Any())
            {
                return;
            }

            context.RemoveRange(context.CitizensTasks.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.CitizensTasks.Any())
            {
                return;
            }

            var citizenTask1 = new CitizensTask
            {
                Description = "Do task number one",
                ReminderDate = new DateTime(2021,12,10),
                UserId="1",
                User=new AppUser { Name="user1@mail.ru"}              
            };

            var citizenTask2 = new CitizensTask
            {
                Description = "Do task number two",
                ReminderDate = new DateTime(2021, 8, 10),
                UserId = "2",
                User = new AppUser { Name = "user2@mail.ru" }

            };
            var citizenTask3 = new CitizensTask
            {
                Description = "Do task number three",
                ReminderDate = new DateTime(2021, 9, 25),
                UserId = "3",
                User = new AppUser { Name = "user3@mail.ru" }

            };

            context.AddRange(citizenTask1, citizenTask2, citizenTask3);
            context.SaveChanges();
        }
    }
}
