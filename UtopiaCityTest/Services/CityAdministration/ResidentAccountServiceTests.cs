using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CityAdministration;
using UtopiaCityTest.Services;
using Xunit;

namespace UtopiaCityTest.CityAdministration.Services
{
    public class ResidentAccountServiceTests : BaseServiceTest
    {
        public ResidentAccountServiceTests()
        {
            Setup();
        }

        [Fact]
        public async Task GetResidentAccounts_ReturnsItems_IfItExistsInDb()
        {
            // arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            using (var context = new ApplicationDbContext(localOptions))
            {
                context.ResidentAccount.Add(new ResidentAccount { Id = "1", FirstName = "Daniil", FamilyName = "Andreev", BirthDate = new DateTime(1984, 08, 14), Gender = Gender.Male });
                context.ResidentAccount.Add(new ResidentAccount { Id = "2", FirstName = "Ksenija", FamilyName = "Belova", BirthDate = new DateTime(2001, 12, 30), Gender = Gender.Female });
                context.ResidentAccount.Add(new ResidentAccount { Id = "3", FirstName = "Diana", FamilyName = "Makarova", BirthDate = new DateTime(1986, 07, 25), Gender = Gender.Female });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(localOptions))
            {
                var service = new ResidentAccountService(context);

                // act
                var result = await service.GetResidentAccounts();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => Assert.Equal("1", item.Id),
                    item => Assert.Equal("2", item.Id),
                    item => Assert.Equal("3", item.Id));
                Assert.Collection(result,
                    item => Assert.Equal("Daniil", item.FirstName),
                    item => Assert.Equal("Ksenija", item.FirstName),
                    item => Assert.Equal("Diana", item.FirstName));
                Assert.Collection(result,
                    item => Assert.Equal("Andreev", item.FamilyName),
                    item => Assert.Equal("Belova", item.FamilyName),
                    item => Assert.Equal("Makarova", item.FamilyName));
                Assert.Collection(result,
                    item => Assert.Equal(new DateTime(1984, 08, 14), item.BirthDate),
                    item => Assert.Equal(new DateTime(2001, 12, 30), item.BirthDate),
                    item => Assert.Equal(new DateTime(1986, 07, 25), item.BirthDate));

                var result2 = await service.GetResidentAccountById("1");

                // assert
                Assert.Equal("Daniil", result2.FirstName);
            }
        }

        [Fact]
        public async Task GetResidentAccounts_ReturnsItems_IfItExistsInDb_Alternative()
        {
            // arrange

            using (var context = new ApplicationDbContext(options))
            {
                var service = new ResidentAccountService(context);

                // act
                var result = await service.GetResidentAccounts();
                // assert
                Assert.Equal(10, result.Count);
                Assert.Collection(result,
                    item => Assert.Equal("Ksenija", item.FirstName),
                    item => item.BirthDate.Equals(""),
                    item => item.FirstName.Equals("Julija"),
                    item => item.FirstName.Equals("Daniil"),
                    item => item.FirstName.Equals("Kirill"),
                    item => item.FirstName.Equals("Ksenija"),
                    item => item.FirstName.Equals("Artjom"),
                    item => item.FirstName.Equals("Diana"),
                    item => item.FirstName.Equals("Dmitrij"),
                    item => item.FirstName.Equals("Elizaveta"));
            }
        }

        [Fact]
        public async Task GetResidentAccounts_ReturnsItems_IfItExistsInDb_Alternative2()
        {
            // arrange
            using (var context = new ApplicationDbContext(options))
            {
                var service = new ResidentAccountService(context);

                // act
                var accounts = await service.GetResidentAccounts();
                var result = accounts.FirstOrDefault(a => a.FamilyName.Equals("Alehina"));

                // assert
                Assert.Equal("Julija", result.FirstName);
            }
        }
    }
}
