using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;
using UtopiaCityTest.Services;

namespace UtopiaCityTest.Common.ObjectsForTests
{
    public class BankObjectsForTests: BaseServiceTest
    {
        public async void AddItem_Banks()
        {
            //arrange
            TearDown();

            using (var context = new ApplicationDbContext(options))
            {
                context.Banks.Add(new Bank { Id = "1", Name = "Al-Hilal bank", BIK = "HLALKZKZ" });
                context.Banks.Add(new Bank { Id = "2", Name = "Kaspi bank", BIK = "KASPKZKZ" });

                context.SaveChanges();
            }
        }
    }
}
