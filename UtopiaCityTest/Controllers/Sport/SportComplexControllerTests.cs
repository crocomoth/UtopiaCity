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
        private readonly Mock<SportComplexService> _sportComplexServiceMock;
        private readonly IMapper _mapper;

        public SportComplexControllerTests()
        {
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportComplexViewModelForTests = SportObjectsForTests.SportComplexViewModelForTests();
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _sportComplexServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportComplexProfile());
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportComplexes_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetAllSportComplexes()).ReturnsAsync(() => new List<SportComplex>());
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllSportComplexes().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<List<SportComplexViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportComplexViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("id")).ReturnsAsync(() => new SportComplex());
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details("id").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ReturnsDefaultView()
        {
            //arrange
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

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
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(_sportComplexForTests);
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<SportComplexViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportComplexViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(_sportComplexForTests);
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

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
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(_sportComplexViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllSportComplexesView()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(_sportComplexForTests);
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }

        [Fact]
        public void Edit_MethodPost_RedirectsToAllSportComplexesView()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.UpdateSportComplexInDb(_sportComplexForTests));
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", _sportComplexViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportComplexes", result.ActionName);
        }
        #endregion
        #region TestsWithNulls
        [Fact]
        public void Details_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportComplexViewModelNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(default(SportComplex));
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Delete(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexNullResult = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportComplexNullResult.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(default(SportComplex));
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.DeleteConfirmed(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexNullResult = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportComplexNullResult.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexById("1")).ReturnsAsync(default(SportComplex));
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Edit(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexNull = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportComplexNull.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportComplexController(_sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Edit(null, _sportComplexViewModelForTests).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexViewModelNullResult = controller.Edit("100", null).GetAwaiter().GetResult() as ViewResult;
            ViewResult differentIdsResult = controller.Edit("100", _sportComplexViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportComplexViewModelNullResult.ViewName);
            Assert.Equal("Error", differentIdsResult.ViewName);
        }
        #endregion
    }
}
