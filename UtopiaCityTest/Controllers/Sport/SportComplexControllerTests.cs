using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Data;
using UtopiaCity.Helpers.AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportComplexControllerTests
    {
        private readonly SportComplex _sportComplexForTests;
        private readonly SportComplexViewModel _sportComplexViewModelForTests;
        private readonly Mock<ApplicationDbContext> _dbContext;
        private readonly Mock<SportComplexService> _serviceMock;
        private readonly IMapper _mapper;

        public SportComplexControllerTests()
        {
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexViewModelForTests = SportObjectsForTests.SportComplexViewModelForTests();
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _serviceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportComplexProfile());
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportComplexes_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetAllSportComplexes()).Returns(() => new List<SportComplex>());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllSportComplexes() as ViewResult;

            //assert
            Assert.IsType<List<SportComplexViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportComplexViewModel_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("id")).Returns(() => new SportComplex());
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details("id") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ReturnsDefaultView()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.Null(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportComplexViewModel_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(_sportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportComplexViewModel_ReturnsDefaultView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(_sportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }
        #endregion
        #region RedirectToActionTests
        [Fact]
        public void Create_MethodPost_RedirectsToAllSportComplexesView()
        {
            //arrange
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(_sportComplexViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllSportComplexesView()
        {
            //arrange
            _serviceMock.Setup(x => x.GetSportComplexById("1")).Returns(_sportComplexForTests);
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1") as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void Edit_MethodPost_RedirectsToAllSportComplexesView()
        {
            //arrange
            _serviceMock.Setup(x => x.UpdateSportComplexInDb(_sportComplexForTests));
            var controller = new SportComplexController(_serviceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", _sportComplexViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }
        #endregion
    }
}
