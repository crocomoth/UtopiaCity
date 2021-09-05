using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Life;
using UtopiaCity.Services.Sport;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportControllerTests
    {
        [Fact]
        public void ModelObjectType()
        {
            //arrange
            var applicationDbContextMock = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();

            var sportComplexServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(applicationDbContextMock);
            sportComplexServiceMock.Setup(x => x.GetAllSportComplexes()).ReturnsAsync(new List<SportComplex>());

            var sportEventServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportEventService>(applicationDbContextMock);
            sportEventServiceMock.Setup(x => x.GetAllSportEvents()).ReturnsAsync(new List<SportEvent>());

            var lifeServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, LifeService>(applicationDbContextMock);

            var controller = new SportController(sportComplexServiceMock.Object, sportEventServiceMock.Object, lifeServiceMock.Object);

            //act
            ViewResult viewResult = controller.Index().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<List<SportComplex>>(viewResult.ViewData["SportComplexes"]);
            Assert.IsType<List<SportEvent>>(viewResult.ViewData["SportEvents"]);
        }
    }
}
