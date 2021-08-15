using System;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.PublicCatering;
using UtopiaCity.Services.Emergency;
using UtopiaCity.Services.PublicCatering.RestaurantType;
using Xunit;

namespace UtopiaCityTest.Services
{
    public class PublicCateringServiceTests : BaseServiceTest
    {
        public PublicCateringServiceTests()
        {
            Setup();
        }
        
        [Fact]
        public async void GetPublicCatering_ReturnsItems_IfItExistsInDb()
        {
            // arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            await using (var context = new ApplicationDbContext(localOptions))
            {
                context.RestaurantTypes.Add(new RestaurantType { Id = "1", Name = "wdwdwdw"});
                context.RestaurantTypes.Add(new RestaurantType { Id = "2", Name = "wdwdwdw"});
                context.RestaurantTypes.Add(new RestaurantType { Id = "3", Name = "wdwdwdw"});
                context.SaveChanges();
            }

            await using(var context = new ApplicationDbContext(localOptions))
            {
                var service = new RestaurantTypeService(context);

                // act
                var result = await service.GetRestaurantTypes();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("1"),
                    item => item.Id.Equals("2"),
                    item => item.Id.Equals("3"));
            }
        }
        [Fact]
        public async void GetPublicCatering_ReturnsItems_IfItExistsInDb_Alternative2()
        {
            // arrange
            await using (var context = new ApplicationDbContext(options))
            {
                var service = new RestaurantTypeService(context);

                // act
                var result = await service.GetRestaurantTypes();

                // assert
                Assert.Equal(5, result.Count);
                Assert.Collection(result,
                    item => item.Name.Equals("Caffe"),
                    item => item.Name.Equals("Bar"),
                    item => item.Name.Equals("Restaurant"),
                    item => item.Name.Equals("Eatery"),
                    item => item.Name.Equals("Teahouse"));
            }
        }
        
    }
}