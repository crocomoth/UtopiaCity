using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using UtopiaCity.Controllers.Sport;
using UtopiaCity.Data;
using UtopiaCity.Helpers.Automapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.Services.Sport;
using UtopiaCity.ViewModels.Sport;
using UtopiaCityTest.Common.ObjectsForTests;
using Xunit;

namespace UtopiaCityTest.Controllers.Sport
{
    public class RequestToAdministrationControllerTests
    {
        private readonly Mock<ApplicationDbContext> _dbContextMock;
        private readonly Mock<RequestToAdministrationService> _requestToAdministrationServiceMock;
        private readonly Mock<SportComplexService> _sportComplexServiceMock;
        private readonly IMapper _mapper;

        private readonly SportComplex _sportComplexForTests;
        private readonly RequestToAdministration _requestToAdministrationForTests;
        private readonly RequestToAdministrationViewModel _requestToAdministrationViewModelForTests;

        public RequestToAdministrationControllerTests()
        {
            _dbContextMock = BasicClassForSportTests.CreateDbContextMock<ApplicationDbContext>();
            _requestToAdministrationServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, RequestToAdministrationService>(_dbContextMock);
            _sportComplexServiceMock = BasicClassForSportTests.CreateServiceMock<ApplicationDbContext, SportComplexService>(_dbContextMock);
            _mapper = BasicClassForSportTests.ConfigMapper(new RequestToAdministrationProfile());
            _sportComplexForTests = SportObjectsForTests.SportComplexForTests();
            _requestToAdministrationForTests = SportObjectsForTests.RequestToAdministrationForTests();
            _requestToAdministrationViewModelForTests = SportObjectsForTests.RequestToAdministrationViewModelForTests();
        }

        #region ViewResultViewNameAndModelObjectTypesTests
        [Fact]
        public void AllRequestsToAdministration_ModelObjectType_List_ReturnsDefaultPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetAllRequestsToAdministration()).ReturnsAsync(new List<RequestToAdministration>());
            _sportComplexServiceMock.Setup(x => x.GetAllSportComplexesIds()).ReturnsAsync(new List<string>());
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllRequestsToAdministration().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Null(result.ViewName);
            Assert.IsType<List<RequestToAdministrationViewModel>>(result.ViewData.Model);
            Assert.IsType<bool>(result.ViewData["IsAllRequestToAdministrationPrinted"]);
            Assert.IsType<List<string>>(result.ViewData["SportComplexesIds"]);
        }

        [Fact]
        public void AllRequestsToAdministrationByDate_ModelObjectType_List_ReturnsAllRequestsToAdministrationPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestsToAdministrationByDate(new DateTime(2001, 1, 1))).ReturnsAsync(new List<RequestToAdministration>());
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllRequestsToAdministrationByDate(new DateTime(2001, 1, 1)).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllRequestsToAdministration", result.ViewName);
            Assert.IsType<List<RequestToAdministrationViewModel>>(result.ViewData.Model);
            Assert.IsType<bool>(result.ViewData["IsAllRequestToAdministrationPrinted"]);
        }

        [Fact]
        public void AllRequestsToAdministrationBySportComplexId_ModelObjectType_List_ReturnsAllRequestsToAdministrationPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestsToAdministrationBySportComplexId("1")).ReturnsAsync(new List<RequestToAdministration>());
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.AllRequestsToAdministrationBySportComplexId("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllRequestsToAdministration", result.ViewName);
            Assert.IsType<List<RequestToAdministrationViewModel>>(result.ViewData.Model);
            Assert.IsType<bool>(result.ViewData["IsAllRequestToAdministrationPrinted"]);
        }

        [Fact]
        public void Create_MethodGet_ModelObjectType_Null_ReturnsDefaultPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetAllSportComplexesTitles()).ReturnsAsync(new List<string>());
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Create().GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Null(result.ViewData.Model);
            Assert.Null(result.ViewName);
            Assert.IsType<List<string>>(result.ViewData["SportComplexesTitles"]);
        }

        [Fact]
        public void Delete_MethodGet_ModelObjectType_RequestToAdministrationViewModel_ReturnsDefaultPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(_requestToAdministrationForTests);
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Null(result.ViewName);
            Assert.IsType<RequestToAdministrationViewModel>(result.ViewData.Model);
        }

        [Fact]
        public void Edit_MethodGet_ModelObjectType_RequestToAdministrationViewModel_ReturnsDefaultPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(_requestToAdministrationForTests);
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Null(result.ViewName);
            Assert.IsType<RequestToAdministrationViewModel>(result.ViewData.Model);
        }

        [Fact]
        public void Details_ModelObjectType_RequestToAdministrationViewModel_ReturnsDefaultPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(_requestToAdministrationForTests);
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult result = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.NotNull(result);
            Assert.Null(result.ViewName);
            Assert.IsType<RequestToAdministrationViewModel>(result.ViewData.Model);
        }
        #endregion
        #region RedirectToActionTests
        [Fact]
        public void Create_MethodPost_RedirectsToAllRequestsToAdministration()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync("1");
            _requestToAdministrationServiceMock.Setup(x => x.AddRequestToDb(_requestToAdministrationForTests));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Create(_requestToAdministrationViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllRequestsToAdministration", result.ActionName);
        }

        [Fact]
        public void Delete_MethodPost_RedirectsToAllRequestsToAdministration()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(_requestToAdministrationForTests);
            _requestToAdministrationServiceMock.Setup(x => x.RemoveRequestFromDb(_requestToAdministrationForTests));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllRequestsToAdministration", result.ActionName);
        }

        [Fact]
        public void Edit_MethodPost_RedirectsToAllRequestsToAdministration()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexByTitle("title_1")).ReturnsAsync(_sportComplexForTests);
            _sportComplexServiceMock.Setup(x => x.UpdateSportComplexInDb(_sportComplexForTests));
            _requestToAdministrationServiceMock.Setup(x => x.UpdateRequestInDb(_requestToAdministrationForTests));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            RedirectToActionResult result = controller.Edit("1", _requestToAdministrationViewModelForTests).GetAwaiter().GetResult() as RedirectToActionResult;

            //assert
            Assert.NotNull(result);
            Assert.Equal("AllRequestsToAdministration", result.ActionName);
        }
        #endregion
        #region TestsWithNulls
        [Fact]
        public void Create_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexIdByTitle("title_1")).ReturnsAsync(default(string));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult requestToAdministrationViewModelNullResult = controller.Create(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexIdNullResult = controller.Create(_requestToAdministrationViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", requestToAdministrationViewModelNullResult.ViewName);
            Assert.Equal("Error", sportComplexIdNullResult.ViewName);
        }

        [Fact]
        public void Delete_MethodGet_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(default(RequestToAdministration));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Delete(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult requestToAdministrationNullResult = controller.Delete("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", requestToAdministrationNullResult.ViewName);
        }

        [Fact]
        public void Delete_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(default(RequestToAdministration));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.DeleteConfirmed(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult requestToAdministrationNullResult = controller.DeleteConfirmed("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", requestToAdministrationNullResult.ViewName);
        }

        [Fact]
        public void Edit_MethodGet_InvalidData_ReturnsErrorPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(default(RequestToAdministration));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Edit(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult requestToAdministrationNullResult = controller.Edit("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", requestToAdministrationNullResult.ViewName);
        }

        [Fact]
        public void Edit_MethodPost_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _sportComplexServiceMock.Setup(x => x.GetSportComplexByTitle("title_1")).ReturnsAsync(default(SportComplex));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Edit(null, _requestToAdministrationViewModelForTests).GetAwaiter().GetResult() as ViewResult;
            ViewResult requestToAdministrationNullResult = controller.Edit("1", null).GetAwaiter().GetResult() as ViewResult;
            ViewResult sportComplexNullResult = controller.Edit("1", _requestToAdministrationViewModelForTests).GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", requestToAdministrationNullResult.ViewName);
            Assert.Equal("Error", sportComplexNullResult.ViewName);
        }

        [Fact]
        public void Details_InvalidInputData_ReturnsErrorPage()
        {
            //arrange
            _requestToAdministrationServiceMock.Setup(x => x.GetRequestToAdministrationById("1")).ReturnsAsync(default(RequestToAdministration));
            var controller = new RequestToAdministrationController(_requestToAdministrationServiceMock.Object, _sportComplexServiceMock.Object, _mapper);

            //act
            ViewResult idNullResult = controller.Details(null).GetAwaiter().GetResult() as ViewResult;
            ViewResult requestToAdministrationNullResult = controller.Details("1").GetAwaiter().GetResult() as ViewResult;

            //assert
            Assert.Equal("Error", idNullResult.ViewName);
            Assert.Equal("Error", requestToAdministrationNullResult.ViewName);
        }
        #endregion
    }
}
