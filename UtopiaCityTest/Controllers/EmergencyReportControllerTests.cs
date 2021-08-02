using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using UtopiaCity.Controllers.Emergency;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;
using Xunit;

namespace UtopiaCityTest.Controllers
{
    public class EmergencyReportControllerTests
    {
        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            // arrange
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            var serviceMock = new Mock<EmergencyReportService>(applicationDbContextMock.Object);

            serviceMock.Setup(x => x.GetEmergencyReports()).ReturnsAsync(() => new List<EmergencyReport>());

            var controller = new EmergencyReportController(serviceMock.Object);

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "EmergencyReportListView");
        }
    }
}
