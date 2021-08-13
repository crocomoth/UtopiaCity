using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerModelObjectTypeTests : BasicClassForSportTests<SportComplexService>
    {
        public SportComplexControllerModelObjectTypeTests() : base() { }

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

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.Null(result.ViewData.Model);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportComplexViewModel()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(SportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportComplexViewModel()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(SportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
        }
    }
}
