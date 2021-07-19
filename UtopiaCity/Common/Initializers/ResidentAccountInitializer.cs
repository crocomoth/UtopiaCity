﻿using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration.ResidentAccount;

namespace UtopiaCity.Common.Initializers
{
    public class ResidentAccountInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.RersidentAccount.Any())
            {
                return;
            }

            context.RemoveRange(context.RersidentAccount.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.RersidentAccount.Any())
            {
                return;
            }

            var account1 = new RersidentAccount
            {
                FirstName = "Marina",
                FamilyName = "Abramova",
                BirthDate = new DateTime(1987, 05, 22),
                Gender = "Female"
            };

            var account2 = new RersidentAccount
            {
                FirstName = "Konstantin",
                FamilyName = "Alekseev",
                BirthDate = new DateTime(1988, 09, 05),
                Gender = "Male"
            };

            var account3 = new RersidentAccount
            {
                FirstName = "Julija",
                FamilyName = "Alehina",
                BirthDate = new DateTime(1984, 08, 14),
                Gender = "Female"
            };

            var account4 = new RersidentAccount
            {
                FirstName = "Daniil",
                FamilyName = "Andreev",
                BirthDate = new DateTime(1976, 03, 01),
                Gender = "Male"
            };

            var account5 = new RersidentAccount
            {
                FirstName = "Kirill",
                FamilyName = "Artamonov",
                BirthDate = new DateTime(1990, 11, 12),
                Gender = "Male"
            };

            var account6 = new RersidentAccount
            {
                FirstName = "Ksenija",
                FamilyName = "Belova",
                BirthDate = new DateTime(2001, 12, 30),
                Gender = "Female"
            };

            var account7 = new RersidentAccount
            {
                FirstName = "Artjom",
                FamilyName = "Birjukov",
                BirthDate = new DateTime(1998, 11, 17),
                Gender = "Male"
            };

            var account8 = new RersidentAccount
            {
                FirstName = "Diana",
                FamilyName = "Makarova",
                BirthDate = new DateTime(1986, 07, 25),
                Gender = "Female"
            };

            var account9 = new RersidentAccount
            {
                FirstName = "Dmitrij",
                FamilyName = "Poljakov",
                BirthDate = new DateTime(1976, 02, 14),
                Gender = "Male"
            };

            var account10 = new RersidentAccount
            {
                FirstName = "Elizaveta",
                FamilyName = "Sokolova",
                BirthDate = new DateTime(1983, 10, 01),
                Gender = "Female"
            };

            context.AddRange(account1, account2, account3, account4, account5, account6, account7, account8, account9, account10);
            context.SaveChanges();
        }
    }
}
