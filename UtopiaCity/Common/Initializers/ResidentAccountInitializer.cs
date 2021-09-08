using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.Initializers
{
    public class ResidentAccountInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.ResidentAccount.Any())
            {
                return;
            }

            context.RemoveRange(context.ResidentAccount.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.ResidentAccount.Any())
            {
                return;
            }

            var account1 = new ResidentAccount
            {
                FirstName = "Marina",
                FamilyName = "Abramova",
                BirthDate = new DateTime(1987, 05, 22),
                Gender = Gender.Female,
                Email = "marina@gmail.com",
                RegistrationAddress = "79 Ronda Vista Place APT 472 UtopiaCity, 18064",
                Phone = "+1-234-567897"
            };

            var account2 = new ResidentAccount
            {
                FirstName = "Konstantin",
                FamilyName = "Alekseev",
                BirthDate = new DateTime(1988, 09, 05),
                Gender = Gender.Male,
                Email = "konstantin@gmail.com",
                RegistrationAddress = "192 E Lovett Street APT 430 UtopiaCity, 18064",
                Phone = "+1-234-345673"
            };

            var account3 = new ResidentAccount
            {
                FirstName = "Julija",
                FamilyName = "Alehina",
                BirthDate = new DateTime(1984, 08, 14),
                Gender = Gender.Female,
                Email = "jul@gmail.com",
                RegistrationAddress = "149 W National Boulevard APT 298 UtopiaCity, 18064",
                Phone = "+1-345-896453"
            };

            var account4 = new ResidentAccount
            {
                FirstName = "Daniil",
                FamilyName = "Andreev",
                BirthDate = new DateTime(1976, 03, 01),
                Gender = Gender.Male,
                Email = "dan@gmail.com",
                RegistrationAddress = "36 Nicolet Avenue APT 678 UtopiaCity, 18064",
                Phone = "+1-564-673345"
            };

            var account5 = new ResidentAccount
            {
                FirstName = "Kirill",
                FamilyName = "Artamonov",
                BirthDate = new DateTime(1990, 11, 12),
                Gender = Gender.Male,
                Email = "kirill@gmail.com",
                RegistrationAddress = "199 S Wilton Place APT 866 UtopiaCity, 18064",
                Phone = "+1-738-683957"
            };

            var account6 = new ResidentAccount
            {
                FirstName = "Ksenija",
                FamilyName = "Belova",
                BirthDate = new DateTime(2001, 12, 30),
                Gender = Gender.Female,
                Email = "ks01@gmail.com",
                RegistrationAddress = "92 N Algoma Avenue APT 56 UtopiaCity, 18064",
                Phone = "+1-239-759595"
            };

            var account7 = new ResidentAccount
            {
                FirstName = "Artjom",
                FamilyName = "Birjukov",
                BirthDate = new DateTime(1998, 11, 17),
                Gender = Gender.Male,
                Email = "art98@gmail.com",
                RegistrationAddress = "49 Delor Drive APT 636 UtopiaCity, 18064",
                Phone = "+1-555-766864"
            };

            var account8 = new ResidentAccount
            {
                FirstName = "Diana",
                FamilyName = "Makarova",
                BirthDate = new DateTime(1986, 07, 25),
                Gender = Gender.Female,
                Email = "makarova@gmail.com",
                RegistrationAddress = "76 New Depot Street APT 420 UtopiaCity, 18064",
                Phone = "+1-466-572346"
            };

            var account9 = new ResidentAccount
            {
                FirstName = "Dmitrij",
                FamilyName = "Poljakov",
                BirthDate = new DateTime(1976, 02, 14),
                Gender = Gender.Male,
                Email = "den1976@gmail.com",
                RegistrationAddress = "177 Saint Susan Place APT 4 UtopiaCity, 18064",
                Phone = "+1-999-567442"
            };

            var account10 = new ResidentAccount
            {
                FirstName = "Elizaveta",
                FamilyName = "Sokolova",
                BirthDate = new DateTime(1983, 10, 01),
                Gender = Gender.Female,
                Email = "sokol@gmail.com",
                RegistrationAddress = "194 Byrne Court APT 656 UtopiaCity, 18064",
                Phone = "+1-342-342515"
            };

            context.AddRange(account1, account2, account3, account4, account5, account6, account7, account8, account9, account10);
            context.SaveChanges();
        }
    }
}
