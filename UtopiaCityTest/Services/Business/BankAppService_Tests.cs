using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;
using UtopiaCity.Services.Business;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Services.Business
{
    public class BankAppService_Tests: BankObjectsForTests
    {
        public BankAppService_Tests()
        {
            Setup();
        }

        [Fact]
        public async void Bank_GetAll()
        {
            AddItem_Banks();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new BankService(context);

                // Act
                var result = await service.GetAll();

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("1"),
                    item => item.Id.Equals("2"));
            }
        }

        [Fact]
        public async void Bank_GetById()
        {
            AddItem_Banks();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new BankService(context);

                // Act
                var result = await service.GetById("1");

                // Assert
                Assert.Equal("1", result.Id);
            }
        }

        [Fact]
        public async void Bank_Update()
        {
            AddItem_Banks();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new BankService(context);
                var bank = new Bank { Id = "1", Name = "Halyk bank", BIK = "HALYKAKZ" };
                await service.Update(bank);

                // Act
                var result = await service.GetById("1");

                // Assert
                Assert.Equal("1", result.Id);
                Assert.Equal("Halyk bank", result.Name);
                Assert.Equal("HALYKAKZ", result.BIK);
            }
        }

        [Fact]
        public async void Bank_Remove()
        {
            AddItem_Banks();

            using (var context = new ApplicationDbContext(options))
            {
                var service = new BankService(context);

                // Act
                var bank = new Bank { Id = "1", Name = "Al-Hilal bank", BIK = "HLALKZKZ" };
                await service.Delete(bank);

                var result = await service.GetById("1");

                // Assert
                Assert.Null(result);
            }
        }
    }
}
