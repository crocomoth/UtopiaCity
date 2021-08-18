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
    public class SportEventControllerTests
    {
        private readonly Mock<ApplicationDbContext> _dbContext;
        private readonly Mock<SportEventService> _sportEventService;
        private readonly Mock<SportComplexService> _sportComplexService;
        private readonly IMapper _mapper;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportEvent _sportEventForTests;
        private readonly SportEventViewModel _sportEventViewModelForTests;
        private readonly SportEvent[] _sportEventsForTests;

        public SportEventControllerTests()
        {
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _sportComplexService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _sportEventService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportEventService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportComplexProfile(), new SportEventProfile());
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _sportEventViewModelForTests = SportObjectsForTests.SportEventViewModelForTests();
            _sportEventsForTests = SportObjectsForTests.ArrayOfSportEventsForTests();
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportEvents_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _sportEventService.Setup(x => x.GetAllSportEvents()).Returns(new System.Collections.Generic.List<SportEvent>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.AllSportEvents() as ViewResult;

            //assert
            Assert.IsType<List<SportEventViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ViewData_ListOfStrings_ReturnsDefaultView()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetAllSportComplexesTitles()).Returns(new List<string>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.IsType<List<string>>(result.ViewData["SportComplexesTitles"]);
            Assert.Null(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportEventViewModel_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).Returns(_sportEventForTests);
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.IsType<SportEventViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportEventViewModel_ViewBagType_ListOfStrings_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).Returns(_sportEventForTests);
            _sportComplexService.Setup(x => x.GetAllSportComplexesTitles()).Returns(new List<string>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.IsType<List<string>>(result.ViewData["SportComplexesTitles"]);
            Assert.IsType<SportEventViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportEventViewModel_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).Returns(_sportEventForTests);
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details("1") as ViewResult;

            //assert
            Assert.IsType<SportEventViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }
        #endregion
        #region RedirectToActionTests
        [Fact]
        public void Create_MethodPost_RedirectsToAllSportEvents()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).Returns("1");
            _sportEventService.Setup(x => x.AddSportEventToDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(_sportEventViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportEvents", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllSportEvents()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).Returns(_sportEventForTests);
            _sportEventService.Setup(x => x.RemoveSportEventFromDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1") as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportEvents", result.ActionName);
        }

        [Fact]
        public void Edit_MethodPost_RedirectsToAllSportEvents()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).Returns("1");
            _sportEventService.Setup(x => x.UpdateSportEventInDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", _sportEventViewModelForTests) as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportEvents", result.ActionName);
        }
        #endregion
        #region TestsWithNulls
        [Fact]
        public void Create_MethodPost_SportEventViewModelNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Create(null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportComplexIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).Returns(default(string));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Create(_sportEventViewModelForTests) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete(null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).Returns(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1") as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.DeleteConfirmed(null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).Returns(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.DeleteConfirmed("1") as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_IdNull_ReturnErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit(null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).Returns(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit(null, _sportEventViewModelForTests) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_SportEventViewModelNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1", null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_SportComplexIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).Returns(default(string));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1", _sportEventViewModelForTests) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Details_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details(null) as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Details_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).Returns(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details("1") as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }
        #endregion
    }
}
