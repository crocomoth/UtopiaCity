using Microsoft.AspNetCore.Mvc;
using System;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Models.Sport.Enums;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerRedirectToActionTests : DbContextAndServiceMocking<SportComplexService>
    {
        public SportComplexControllerRedirectToActionTests()
        {
            BasicMocking();
        }

        [Fact]
        public void RedirectingByCreate_MethodPost()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(SportComplexViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

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
