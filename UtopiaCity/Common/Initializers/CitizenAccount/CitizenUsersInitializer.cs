using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.Initializers.CitizenAccount
{
    /// <summary>
    /// For all users created this initializers U can use password "Ab1234"
    /// </summary>
    public class CitizenUsersInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.AppUser.Any())
            {
                return;
            }
            context.RemoveRange(context.AppUser.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.AppUser.Any())
            {
                return;
            }

            var citizen1 = new AppUser
            {
                Id="1",
                UserName= "Jenya@mail.ru",
                NormalizedUserName= "JENYA@MAIL.RU",
                Email = "Jenya@mail.ru",
                NormalizedEmail= "JENYA@MAIL.RU",
                PasswordHash = "AQAAAAEAACcQAAAAEGZ6iWOwwL1aLRNIAXp6kp3rRSbIwHBa9H9gZ8g0cmTIF6kNhP6Z+Hnth7FEbMVMgQ==",
                SecurityStamp= "2KOXXTWGTCIBRMBBO2MU6LMLX2ASNEIQ",
                ConcurrencyStamp= "8a8f307d-59ce-408e-8c0b-30addb76e460",
                Name="Jenya",
                Surname = "Ivanov",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2000, 10, 2),
            };

            var citizen2 = new AppUser
            {
                Id = "2",
                UserName = "Igor@mail.ru",
                NormalizedUserName = "IGOR@MAIL.RU",
                Email = "Igor@mail.ru",
                NormalizedEmail = "IGOR@MAIL.RU",
                PasswordHash = "AQAAAAEAACcQAAAAEAfm5rN7K6+pWxg/Q+fo8ooVtTlRwR/iWsbUa41psylsjHx/MY9F6JMJzPFGnoKB5Q==",
                SecurityStamp = "H77W3RVQ42XSNLIFEDGEBFOIKIZXM7ST",
                ConcurrencyStamp = "0a4002a5-ed2f-4428-85c6-b3a1f7960d8d",
                Name = "Igor",
                Surname = "Petrov",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2002, 3, 25),
            };

            var citizen3 = new AppUser
            {
                Id = "3",
                UserName = "Ashot@mail.ru",
                NormalizedUserName = "ASHOT@MAIL.RU",
                Email = "Ashot@mail.ru",
                NormalizedEmail = "ASHOT@MAIL.RU",
                PasswordHash = "AQAAAAEAACcQAAAAEPrAK5mmjIJbcU64mNFvxBldzOH3/H0gX/fqvRwB0/EVlJOUu4FIBhDVfZFJzI0uNg==",
                SecurityStamp = "GYCLOZUB6BKD6BJLLQJRQO5DYV6KBEBL",
                ConcurrencyStamp = "81c8b9cf-5cbf-4c9f-ade5-ae3ba48a2c17",
                Name = "Ashot",
                Surname = "Vazgenov",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2004, 11, 15),
            };

            var citizen4 = new AppUser
            {
                Id = "4",
                UserName = "Natasha@mail.ru",
                NormalizedUserName = "NATASHA@MAIL.RU",
                Email = "Natasha@mail.ru",
                NormalizedEmail = "NATASHA@MAIL.RU",
                PasswordHash = "AQAAAAEAACcQAAAAELz2abhongggf7AfTul3pdsQzUmoJv89ND8psLhiaZX8wCFLjV6jg2lRksepGF60QQ==",
                SecurityStamp = "AFNTT2DGIPOWIKCRIDA3DQGNN75IOOAV",
                ConcurrencyStamp = "482ecbf5-a338-44ff-8a9d-7b4d7a08b4b3",
                Name = "Natasha",
                Surname = "Petrova",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2001, 8, 5),
            };


            context.AddRange(citizen1, citizen2, citizen3, citizen4);
            context.SaveChanges();
        }
    }
}
