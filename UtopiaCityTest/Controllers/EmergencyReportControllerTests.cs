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
    public class EmergencyReportControllerTests : IDisposable
    {
        private EmergencyReportController controller;
        private Mock<EmergencyReportService> serviceMock;

        public EmergencyReportControllerTests()
        {
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            serviceMock = new Mock<EmergencyReportService>(applicationDbContextMock.Object);
            controller = new EmergencyReportController(serviceMock.Object);
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            // arrange
            serviceMock.Setup(x => x.GetEmergencyReports()).ReturnsAsync(() => new List<EmergencyReport>());

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "EmergencyReportListView");
        }

        [Fact]
        public void Index_ReturnsViewWithModel_WhenThereIsModel()
        {
            // arrange
            var model = new EmergencyReport
            {
                Id = "1",
                Report = "Report",
                ReportTime = DateTime.Now
            };

            serviceMock.Setup(x => x.GetEmergencyReports()).ReturnsAsync(() => new List<EmergencyReport> { model });

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "EmergencyReportListView");

            var viewModel = viewResult.Model as List<EmergencyReport>;
            Assert.True(viewModel != null);
            Assert.True(viewModel.Count == 1);
            Assert.Equal(model, viewModel[0]);
        }
    }
}
