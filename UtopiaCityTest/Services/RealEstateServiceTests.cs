using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Services.HousingSystem;
using Xunit;

namespace UtopiaCityTest.Services
{
    public class RealEstateServiceTests : BaseServiceTest
    {
        public RealEstateServiceTests()
        {
            Setup();
        }

        [Fact]
        public async void GetRealEstates_ReturnsItem_IfTheyExistInDb()
        {            
            //arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            using (var context = new ApplicationDbContext(localOptions))
            {
                context.RealEstate.Add(new RealEstate { Street = "Test7", EstateType = RealEstateType.Apartment, CompletionYear = 2005, Number = "F7" });
                context.RealEstate.Add(new RealEstate { Street = "Test8", EstateType = RealEstateType.Apartment, CompletionYear = 2005, Number = "F7" });
                context.RealEstate.Add(new RealEstate { Street = "Test9", EstateType = RealEstateType.Apartment, CompletionYear = 2005, Number = "F7" });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(localOptions))
            {
                var service = new RealEstateService(context);

                //act
                var result = await service.GetRealEstates();

                //assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("Test7"),
                    item => item.Id.Equals("Test8"),
                    item => item.Id.Equals("Test9"));
            }
        }

        [Fact]
        public async void GetRealEstates_ReturnsItem_IfTheyExistInDb_Alternative()
        {
            //arrange
            using (var context = new ApplicationDbContext(options))
            {
                var service = new RealEstateService(context);

                //act
                var result = await service.GetRealEstates();

                //assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Street.Equals("Test7"),
                    item => item.Street.Equals("Test8"),
                    item => item.Street.Equals("Test9"));
            }
        }
    }
}
