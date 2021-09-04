using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Common.Initializers
{
    public class FireMessageInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.FireMessage.Any())
            {
                return;
            }

            context.RemoveRange(context.FireMessage.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.FireMessage.Any())
            {
                return;
            }

            var message1 = new FireMessage
            {
                Address = "Address 1",
                FullName = "FullName 1",
                PhoneNumber = "87472897898"
            };

            var message2 = new FireMessage
            {
                Address = "Address 2",
                FullName = "FullName 2",
                PhoneNumber = "87472897891"
            };

            var message3 = new FireMessage
            {
                Address = "Address 3",
                FullName = "FullName 3",
                PhoneNumber = "87472897893"
            };

            context.AddRange(message1, message2, message3);
            context.SaveChanges();
        }
    }
}
