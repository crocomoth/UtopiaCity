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
        private readonly SportEvent _sportEventForTests;
        private readonly SportEventViewModel _sportEventViewModelForTests;

        public SportEventControllerTests()
        {
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _sportComplexService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _sportEventService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportEventService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportComplexProfile(), new SportEventProfile());
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _sportEventViewModelForTests = SportObjectsForTests.SportEventViewModelForTests();
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportEvents_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _sportEventService.Setup(x => x.GetAllSportEvents()).ReturnsAsync(new List<SportEvent>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.AllSportEvents().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<List<SportEventViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ViewData_ListOfStrings_ReturnsDefaultView()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetAllSportComplexesTitles()).ReturnsAsync(new List<string>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Create().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<List<string>>(result.ViewData["SportComplexesTitles"]);
            Assert.Null(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportEventViewModel_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(_sportEventForTests);
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<SportEventViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportEventViewModel_ViewBagType_ListOfStrings_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).ReturnsAsync(_sportEventForTests);
            _sportComplexService.Setup(x => x.GetAllSportComplexesTitles()).ReturnsAsync(new List<string>());
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.IsType<List<string>>(result.ViewData["SportComplexesTitles"]);
            Assert.IsType<SportEventViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportEventViewModel_ReturnsDefaultPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(_sportEventForTests);
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

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
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync("1");
            _sportEventService.Setup(x => x.AddSportEventToDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(_sportEventViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportEvents", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllSportEvents()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).ReturnsAsync(_sportEventForTests);
            _sportEventService.Setup(x => x.RemoveSportEventFromDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.Equal("AllSportEvents", result.ActionName);
        }

        [Fact]
        public void Edit_MethodPost_RedirectsToAllSportEvents()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync("1");
            _sportEventService.Setup(x => x.UpdateSportEventInDb(_sportEventForTests));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", _sportEventViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

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
            ViewResult result = controller.Create(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportComplexIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync(default(string));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Create(_sportEventViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.DeleteConfirmed(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).ReturnsAsync(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_IdNull_ReturnErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventById("1")).ReturnsAsync(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit(null, _sportEventViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_SportEventViewModelNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1", null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_SportComplexIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync(default(string));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1", _sportEventViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Details_IdNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details(null).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Details_SportEventNull_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(default(SportEvent));
            var controller = new SportEventController(_sportEventService.Object, _sportComplexService.Object, _mapper);

            //act
            ViewResult result = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }
        #endregion
    }
}
