using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Controllers.Media;
using UtopiaCity.Data;
using UtopiaCity.Models.Media;
using UtopiaCity.Services.Media;
using Xunit;

namespace UtopiaCityTest.Controllers.Media
{
    public class DataCaptureControllerTests
    {
        private DataCaptureController controller;
        private Mock<DataCaptureService> serviceMock;
        
        public DataCaptureControllerTests()
        {
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            serviceMock = new Mock<DataCaptureService>(applicationDbContextMock.Object);
            controller = new DataCaptureController(applicationDbContextMock.Object, serviceMock.Object);
        }

        [Fact]
        public void IndexReturnsAViewResultWithAListOfDataCaptures()
        {
            // Arrange
            serviceMock.Setup(x => x.GetAllDataCaptures()).ReturnsAsync(GetTestDataCaptures);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<DataCapture>>(
                viewResult.Model);

            Assert.Equal(GetTestDataCaptures().Count,model.Count);
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            // arrange
            serviceMock.Setup(x => x.GetAllDataCaptures()).ReturnsAsync(() => new List<DataCapture>());

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
        }

        [Fact]
        public void Index_ReturnsViewWithModel_WhenThereIsModel()
        {
            // arrange
            var model = new DataCapture
            {
                Id = "1",
                Content = "TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq",
                Header = "aaaaaaaaaaaaaaaaaaaaaaa"
            };

            serviceMock.Setup(x => x.GetAllDataCaptures()).ReturnsAsync(() => new List<DataCapture> { model });

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);

            var viewModel = viewResult.Model as List<DataCapture>;
            Assert.True(viewModel != null);
            Assert.True(viewModel.Count == 1);
            Assert.Equal(model, viewModel[0]);
        }

        private List<DataCapture> GetTestDataCaptures()
        {
            var dataCaptures = new List<DataCapture>
            {
                new DataCapture { Id="1", Content="TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq"
                , Header="aaaaaaaaaaaaaaaaaaaaaaa"},
                new DataCapture { Id="2", Content="TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq"
                , Header="aaaaaaaaaaaaaaaaaaaaaaa"},
                new DataCapture { Id="3", Content="TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq"
                , Header="aaaaaaaaaaaaaaaaaaaaaaa"},
                new DataCapture { Id="4", Content="TomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqqTomqqqqqqqqqqqqqqqqqqqqqqq"
                , Header="aaaaaaaaaaaaaaaaaaaaaaa"},
            };
            return dataCaptures;
        }
    }

}
