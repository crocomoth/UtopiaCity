using UtopiaCity.Controllers.Sport;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using UtopiaCity.Services.Sport;
using UtopiaCity.Models.Sport;
using System.Collections.Generic;
using UtopiaCity.ViewModels.Sport;
using UtopiaCity.Models.Sport.Enums;
using System;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerViewResultNameTests : DbContextAndServiceMocking<SportComplexService>
    {
        public SportComplexControllerViewResultNameTests()
        {
            BasicMocking();
        }

        [Fact]
        public void ViewSelectedByAllSportComplexes_Default()
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
        public void ViewSelectedByDetails_Default()
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
        public void ViewSelectedByCreate_MethodGet_Default()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        //TODO Think about this method. May be it's better to use InMemoryDb From Services
        [Fact]
        public void ViewSelectedByDelete_MethodGet_Default()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);
            controller.Create(SportComplexViewModelForTests);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.Null(result.ViewName);
        }

        //TODO Think about repeating of this object
        private SportComplexViewModel SportComplexViewModelForTests = new SportComplexViewModel
        {
            SportComplexId = "1",
            SportComplexTitle = "Title",
            Address = "address",
            NumberOfSeats = 100,
            TypeOfSport = TypesOfSport.Athletics,
            BuildDate = new DateTime(2021, 8, 10)
        };
    }
}
