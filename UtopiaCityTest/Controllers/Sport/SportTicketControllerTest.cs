using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Data;
using UtopiaCity.Helpers.Automapper;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.CitizenAccount;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class SportTicketControllerTests
    {
        #region PrivateFields
        private readonly Mock<ApplicationDbContext> _dbContext;
        private readonly Mock<SportTicketService> _sportTicketService;
        private readonly Mock<SportComplexService> _sportComplexService;
        private readonly Mock<SportEventService> _sportEventService;
        private readonly Mock<CitizensAccountService> _appUserAccountService;
        private readonly Mock<CitizenTaskService> _citizensTaskService;
        
        private readonly IMapper _mapper;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;

        private readonly SportTicket _sportTicketForTests;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportEvent _sportEventForTests;
        private readonly AppUser _appUserForTests;
        private readonly List<CitizensTask> _citizensTasks;
        private readonly SportTicketViewModel _sportTicketViewModelForTests;
        #endregion

        public SportTicketControllerTests()
        {
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _sportTicketService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportTicketService>(_dbContext);
            _sportComplexService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _sportEventService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportEventService>(_dbContext);
            _appUserAccountService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, CitizensAccountService>(_dbContext);
            _citizensTaskService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, CitizenTaskService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportTicketProfile());
            _sportTicketForTests = SportObjectsForTests.SportTicketForTests();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _appUserForTests = SportObjectsForTests.AppUserForTests();
            _sportTicketViewModelForTests = SportObjectsForTests.SportTicketViewModelForTests();
            _citizensTasks = SportObjectsForTests.ListOfCitizensTask();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _httpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>())).Returns(new Claim("id", "1"));
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportTickets_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetAllSportTickets("1")).ReturnsAsync(new List<SportTicket>());
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.AllSportTickets().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<SportTicketViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ViewData_ListOfStrings_ReturnsDefaultView()
        {
            //arrange
            _sportEventForTests.SportComplex = _sportComplexForTests;
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(_sportEventForTests);
            _sportEventService.Setup(x => x.GetAllSportEventsTitles()).ReturnsAsync(new List<string>());
            _appUserAccountService.Setup(x => x.GetUserById("1")).ReturnsAsync(_appUserForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Create("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<SportTicketViewModel>(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportTicketViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(_sportTicketForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<SportTicketViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportTicketViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(_sportTicketForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<SportTicketViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }
        #endregion
        #region RedirectToActionTests
        [Fact]
        public void Create_MethodPost_RedirectsToAllSportTickets()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync("1");
            _sportEventService.Setup(x => x.GetSportEventIdByTitle("title_1")).ReturnsAsync("1");
            _appUserAccountService.Setup(x => x.GetUserById("1")).ReturnsAsync(_appUserForTests);
            _sportTicketService.Setup(x => x.AddSportTicketToDb(_sportTicketForTests));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            RedirectToActionResult result = controller.Create(_sportTicketViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllSportTickets", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllSportTickets()
        {
            //arrange
            _sportTicketForTests.SportEvent = _sportEventForTests;
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(_sportTicketForTests);
            _sportTicketService.Setup(x => x.RemoveSportTicketFromDb(_sportTicketForTests));
            _citizensTaskService.Setup(x => x.GetTasksByReminderDate("1")).ReturnsAsync(_citizensTasks);
            _appUserAccountService.Setup(x => x.GetUserById("1")).ReturnsAsync(_appUserForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllSportTickets", result.ActionName);
        }

        #endregion
        #region TestsWithNulls
        [Fact]
        public void AllSportTickets_IdNull_ReturnsErrorPage()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetAllSportTickets("1")).ReturnsAsync(default(List<SportTicket>));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.AllSportTickets().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportEventService.Setup(x => x.GetSportEventByIdWithSportComplex("1")).ReturnsAsync(default(SportEvent));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult idNullResult = controller.Create(default(string)).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportEventNullresult = controller.Create("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportEventNullresult.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportTicketViewModelNull_ReturnsErrorPage()
        {
            //arrange
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Create(default(SportTicketViewModel)).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportEventIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync("1");
            _sportEventService.Setup(x => x.GetSportEventIdByTitle("title_1")).ReturnsAsync(default(string));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Create(_sportTicketViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Create_MethodPost_SportComplexIdNull_ReturnsErrorPage()
        {
            //arrange
            _sportComplexService.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync(default(string));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult result = controller.Create(_sportTicketViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(default(SportTicket));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult idNullResult = controller.Delete(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportTicketNullResult = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportTicketNullResult.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(default(SportTicket));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult idNullResult = controller.DeleteConfirmed(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportTicketNullResult = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportTicketNullResult.ViewName);
        }

        [Fact]
        public void Details_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).ReturnsAsync(default(SportTicket));
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object,
                _appUserAccountService.Object, _citizensTaskService.Object, _mapper, _httpContextAccessor.Object);

            //act
            ViewResult idNullResult = controller.Details(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportTicketNullResult = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", sportTicketNullResult.ViewName);
        }
        #endregion
    }
}