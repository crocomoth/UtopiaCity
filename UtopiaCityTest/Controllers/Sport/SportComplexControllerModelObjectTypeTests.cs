using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerModelObjectTypeTests : DbContextAndServiceMocking<SportComplexService>
    {
        public SportComplexControllerModelObjectTypeTests()
        {
            BasicMocking();
        }

        [Fact]
        public void AllSportComplexes_ModelObjectType_List()
        {
            //arrange
            _serviceMock.Setup(x => x.GetAllSportComplexes()).Returns(() => new List<SportComplex>());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllSportComplexes() as ViewResult;

            //assert
            Assert.IsType<List<SportComplexViewModel>>(result.ViewData.Model);
        }

        [Fact]
        public void Details_ModelObjectType_SportComplexViewModel()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("id")).Returns(() => new SportComplex());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details("id") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
        }
    }
}
