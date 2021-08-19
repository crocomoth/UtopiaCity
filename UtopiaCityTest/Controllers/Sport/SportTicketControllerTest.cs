using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using UtopiaCity.Data;
using UtopiaCity.Helpers.AutoMapper;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.CitizenAccount;
using UtopiaCity.Services.CityAdministration;
using UtopiaCity.Services.Sport;
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
        
        private readonly IMapper _mapper;
        
        private readonly SportTicket _sportTicketForTests;
        private readonly SportComplex _sportComplexForTests;
        private readonly SportEvent _sportEventForTests;
        private readonly AppUser _appUserForTests;
        private readonly SportTicket[] _sportTicketsForTests;
        private readonly SportComplex[] _sportComplexesForTests;
        private readonly SportEvent[] _sportEventsForTests;
        private readonly AppUser[] _appUsersForTests;
        //private readonly SportTicketViewModel _sportTicketViewModel;
        #endregion

        public SportTicketControllerTests()
        {
            _dbContext = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _sportTicketService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportTicketService>(_dbContext);
            _sportComplexService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContext);
            _sportEventService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportEventService>(_dbContext);
            _appUserAccountService = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, CitizensAccountService>(_dbContext);
            _mapper = BasicClassForSportTests.ConfigMapper(new SportTicketProfile());
            _sportTicketForTests = SportObjectsForTests.SportTicketForTests();
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _sportEventForTests = SportObjectsForTests.SportEventForTests();
            _appUserForTests = SportObjectsForTests.AppUserForTests();
            _sportTicketsForTests = SportObjectsForTests.ArrayOfSportTicketsForTests();
            _sportComplexesForTests = SportObjectsForTests.ArrayOfSportComplexesForTests();
            _sportEventsForTests = SportObjectsForTests.ArrayOfSportEventsForTests();
            _appUsersForTests = SportObjectsForTests.ArrayOfAppUsersForTests();
            _sportTicketViewModel = SportObjectsForTests.SportTicketViewModelForTests();
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllSportTickets_ModelObjectType_List_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.AllSportTickets()).Returns(new List<SportTicket>());
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object, _appUserAccountService.Object, _mapper);

            //act
            ViewResult result = controller.AllSportTickets() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<SportTicketViewModel>>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ViewData_ListOfStrings_ReturnsDefaultView()
        {
            //arrange
            //TODO Add ViewBag["SportEventsTitles"] and make AJAX request to db for DateOfTheEvents, SportComplexTitle and SportComplexAddress.
            _sportEventService.Setup(x => x.GetAllSportEventsTitles()).Returns(new List<string>());
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object, _appUserAccountService.Object, _mapper);

            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<List<string>>(result.ViewData["SportEventsTitles"]);
            Assert.Null(result.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_SportTicketViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).Returns(_sportTicketForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object, _appUserAccountService.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1");

            //assert
            Assert.NotNull(result);
            Assert.IsType<SportTicketViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_SportTicketViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).Returns(_sportTicketForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object, _appUserAccountService.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1") as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.IsType<SportTicketViewModel>(result.ViewData.Model);
            Assert.Null(result.ViewName);
        }

        [Fact]
        public void Details_ModelObjectType_SportTicketViewModel_ReturnsDefaultView()
        {
            //arrange
            _sportTicketService.Setup(x => x.GetSportTicketById("1")).Returns(_sportTicketForTests);
            var controller = new SportTicketController(_sportTicketService.Object, _sportComplexService.Object, _sportEventService.Object, _appUserAccountService.Object, _mapper);

            //act
            ViewResult result = controller.Details("1") as ViewResult;

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

        }
        #endregion
    }
}