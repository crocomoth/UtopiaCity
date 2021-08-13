using UtopiaCity.Controllers.Sport;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Sport;
using System.Collections.Generic;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerViewResultNameTests : BasicClassForSportTests<SportComplexService>
    {
        public SportComplexControllerViewResultNameTests() : base() { }

        [Fact]
        public void ViewSelectedByAllSportComplexes_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetAllSportComplexes()).Returns(() => new List<SportComplex>());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllSportComplexes() as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void ViewSelectedByDetails_ReturnsDefaultView()
        {
            //arrrange
            _serviceMock.Setup(x => x.GetSportComplexById("id")).Returns(() => new SportComplex());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details("id") as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void ViewSelectedByCreate_MethodGet_ReturnsDefaultView()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void ViewSelectedByDelete_MethodGet_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(SportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void ViewSelectedByEdit_MethodGet_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(SportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }
    }
}
