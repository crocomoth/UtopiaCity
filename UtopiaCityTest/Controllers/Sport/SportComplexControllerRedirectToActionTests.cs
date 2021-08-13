using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Services.Sport;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerRedirectToActionTests : BasicClassForSportTests<SportComplexService>
    {
        public SportComplexControllerRedirectToActionTests() : base() { }

        [Fact]
        public void RedirectingByCreate_MethodPost_ReturnsAllSportComplexesView()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(SportComplexViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void RedirectByDelete_MethodPost_ReturnsAllSportComplexesView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(SportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1") as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void RedirectByEdit_MethodPost_ReturnsAllSportComplexesView()
        {
            //arrange
            _serviceMock.Setup(x => x.UpdateSportComplexInDb(SportComplexForTests));
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", SportComplexViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }
    }
}
