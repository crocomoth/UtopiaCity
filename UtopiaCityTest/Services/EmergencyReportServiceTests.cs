using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;
using Xunit;

namespace UtopiaCityTest.Services
{
    public class EmergencyReportServiceTests : BaseServiceTest
    {
        public EmergencyReportServiceTests()
        {
            Setup();
        }

        [Fact]
        public async void GetEmergencyReports_ReturnsItems_IfItExistsInDb()
        {
            // arrange
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            using (var context = new ApplicationDbContext(localOptions))
            {
                context.EmergencyReport.Add(new EmergencyReport { Id = "1", Report = "wdwdwdw", ReportTime = DateTime.Now });
                context.EmergencyReport.Add(new EmergencyReport { Id = "2", Report = "wdwdwdw", ReportTime = DateTime.Now });
                context.EmergencyReport.Add(new EmergencyReport { Id = "3", Report = "wdwdwdw", ReportTime = DateTime.Now });

                context.SaveChanges();
            }

            using(var context = new ApplicationDbContext(localOptions))
            {
                var service = new EmergencyReportService(context);

                // act
                var result = await service.GetEmergencyReports();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("1"),
                    item => item.Id.Equals("2"),
                    item => item.Id.Equals("3"));
            }
        }

        [Fact]
        public async void GetEmergencyReports_ReturnsItems_IfItExistsInDb_Alternative()
        {
            // arrange
            using (var context = new ApplicationDbContext(options))
            {
                var service = new EmergencyReportService(context);

                // act
                var result = await service.GetEmergencyReports();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Report.Equals("Report 1"),
                    item => item.Report.Equals("Report 2"),
                    item => item.Report.Equals("Report 3"));
            }
        }

        [Fact]
        public async void GetEmergencyReports_ReturnsItems_IfItExistsInDb_Alternative2()
        {
            // arrange
            using (var context = new ApplicationDbContext(options))
            {
                var service = new EmergencyReportService(context);

                // act
                var result = await service.GetEmergencyReports();

                // assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Report.Equals("Report 1"),
                    item => item.Report.Equals("Report 2"),
                    item => item.Report.Equals("Report 3"));
            }
        }
    }
}
