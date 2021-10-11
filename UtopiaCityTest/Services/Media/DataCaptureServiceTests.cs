using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Media;
using UtopiaCity.Services.Media;
using Xunit;

namespace UtopiaCityTest.Services.Media
{
    public class DataCaptureServiceTests : BaseServiceTest
    {
        public DataCaptureServiceTests()
        {
            Setup();
        }

        [Fact]
        public async void GetDataCaptureReports_ReturnsItems_IfItExistsInDb()
        {
            // arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            using (var context = new ApplicationDbContext(localOptions))
            {
                context.DataCaptures.Add(new DataCapture {
                    Id = "1",
                    Content = "TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq",
                    Header = "aaaaaaaaaaaaaaaaaaaaaaa"
                });
                context.DataCaptures.Add(new DataCapture
                {
                    Id = "2",
                    Content = "TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq",
                    Header = "aaaaaaaaaaaaaaaaaaaaaaa"
                });
                context.DataCaptures.Add(new DataCapture
                {
                    Id = "3",
                    Content = "TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq",
                    Header = "aaaaaaaaaaaaaaaaaaaaaaa"
                });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(localOptions))
            {
                var service = new DataCaptureService(context);

                // act
                var result = await service.GetAllDataCaptures();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("1"),
                    item => item.Id.Equals("2"),
                    item => item.Id.Equals("3"));
            }
        }
    }
}
