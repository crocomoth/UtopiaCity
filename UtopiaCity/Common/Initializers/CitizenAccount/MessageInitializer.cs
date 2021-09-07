using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.Initializers.CitizenAccount
{
    public class MessageInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Messages.Any())
            {
                return;
            }

            context.RemoveRange(context.Messages.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Messages.Any())
            {
                return;
            }

            var message1 = new Message
            {
               Text="Hi Natasha, it's me Jenya",
               When=new DateTime(2021, 8, 10, 20, 12, 15),
               Author= "Jenya@mail.ru",
               Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
               TalkId="1",
            };
            var message2 = new Message
            {
                Text = "How are you?",
                When = new DateTime(2021, 8, 10, 20, 12, 35),
                Author = "Jenya@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                TalkId = "1",
            };
            var message3 = new Message
            {
                Text = "Oooh Hi Jenya",
                When = new DateTime(2021, 8, 10, 20, 13, 18),
                Author = "Natasha@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Natasha@mail.ru"),
                TalkId = "1",
            };
            var message4 = new Message
            {
                Text = "I'm fine. What's new?",
                When = new DateTime(2021, 8, 10, 20, 13, 28),
                Author = "Natasha@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Natasha@mail.ru"),
                TalkId = "1",
            };
            var message5 = new Message
            {
                Text = "Everything ok. I want see you:) How about lunch tommorow?",
                When = new DateTime(2021, 8, 10, 20, 15, 45),
                Author = "Jenya@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                TalkId = "1",
            };
            var message6 = new Message
            {
                Text = "Yeah sure. Call me tommorow",
                When = new DateTime(2021, 8, 10, 20, 16, 3),
                Author = "Natasha@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Natasha@mail.ru"),
                TalkId = "1",
            };

            var message7 = new Message
            {
                Text = "Ok see you",
                When = new DateTime(2021, 8, 10, 20, 16, 3),
                Author = "Jenya@mail.ru",
                Sender = (AppUser)context.Users.FirstOrDefault(x => x.UserName == "Jenya@mail.ru"),
                TalkId = "1",
            };


            context.AddRange(message1,message2,message3,message4,message5,message6,message7);
            context.SaveChanges();
        }
    }
}
