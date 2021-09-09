using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtopiaCity.Controllers.Airport;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;
using UtopiaCity.Utils;
using Xunit;

namespace UtopiaCityTest.Controllers
{
    public class FlightControllerTests : IDisposable
    {
        private FlightController _flightController;
        private Mock<FlightService> _mockService;

        public FlightControllerTests()
        {
            var applicationDbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            var routeApiMock = new Mock<IRouteApi>();
            _mockService = new Mock<FlightService>(applicationDbContextMock.Object, routeApiMock.Object);
            _flightController = new FlightController(_mockService.Object);
            
        }
        public void Dispose()
        {
            
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            //arrange
            _mockService.Setup(x => x.GetFlightList()).Returns(()=> new List<Flight>());

            //act
            var result = _flightController.Index();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "FlightList");
        }

        [Fact]
        public void Index_ReturnsViewWithModel_WhenThereIsModel()
        {
            //arrange 
            var model = new Flight()
            {
                Id = Guid.NewGuid().ToString(),
                ArrivalTime = DateTime.Now.AddDays(1),
                DepartureTime = DateTime.Now,
                FlightNumber = RandomUtil.GenerateRandomString(50).Length,
                DestinationPoint = "Moscow",
                LocationPoint = "Stambul",
                TypeOfAircraft = "PassengerAverageLengthAircraft",
                Weather = "Sunny"
            };
            _mockService.Setup(x => x.GetFlightList()).Returns(() => new List<Flight> { model });

            //act
            var result = _flightController.Index();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "FlightList");

            var viewModelResult = viewResult.Model as List<Flight>;
            Assert.True(viewModelResult != null);
            Assert.True(viewModelResult.Count == 1);
            Assert.Equal(model, viewModelResult[0]);
        }

        [Fact]
        public void Details_ReturnsViewWithModel_WhenThereIsConcreteModel()
        {
            //arrange
            string modelId = Guid.NewGuid().ToString();
            var model = new Flight()
            {
                Id = modelId,
                ArrivalTime = DateTime.Now.AddDays(2),
                DepartureTime = DateTime.Now,
                FlightNumber = RandomUtil.GenerateRandomString(150).Length,
                DestinationPoint = "Stambul",
                LocationPoint = "Moscow",
                TypeOfAircraft = "LiftingCapacityAircraftUpto65",
                Weather = "Rainy"
            };
            _mockService.Setup(x => x.GetFlightById(modelId)).Returns(model);

            //act
            var result = _flightController.Details(modelId);

            //assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "FlightDetailsView");

            var viewModel=viewResult.Model as Flight;
            Assert.True(modelId != null);
            Assert.True(viewModel != null);
            Assert.Equal(model, viewModel);
        }

        [Fact]
        public void Create_ReturnsViewGetRequest_AndTransferTheDataToViewDataDictionary()
        {
            //arrange
            var list = new List<string>();
            list.Add("PassengerShortLengthAircraft");
            list.Add("PassengerAverageLengthAircraft");
            list.Add("PassengerGreatLengthAircraft");
            list.Add("LiftingCapacityAircraftUpTo20");
            list.Add("LiftingCapacityAircraftUpto65");
            list.Add("LiftingCapacityAircraftUpTo120");

            var dictionary = new SelectList(list);
            _mockService.Setup(x => x.GetListOfPlaneTypes()).Returns(list);
          
            //act
            var result = _flightController.Create();

            //assert            
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "FlightCreateView");

            viewResult.ViewData["TypesOfPlanes"] = dictionary;
            Assert.True(viewResult.ViewData.ContainsKey("TypesOfPlanes"));
            Assert.True(viewResult.ViewData["TypesOfPlanes"] != null);
            Assert.True(list != null);
            Assert.True(dictionary != null);
            Assert.True(viewResult.ViewData["TypesOfPlanes"] == dictionary);
            Assert.Equal(list, dictionary.Items);
        }

        [Fact]
        public void Create_PostRequestMethod_ReturnsRedirectionView_WhenThereIsNoModelAndModelStateIsValid()
        {
            //arrange 
            var createdModel = new Flight()
            {
                Id = Guid.NewGuid().ToString(),
                ArrivalTime = DateTime.Now.AddDays(2),
                DepartureTime = DateTime.Now,
                FlightNumber = RandomUtil.GenerateRandomString(150).Length,
                DestinationPoint = "Stambul",
                LocationPoint = "Moscow",
                TypeOfAircraft = "LiftingCapacityAircraftUpto65",
                Weather = "Rainy"
            };            
            _mockService.Setup(x => x.AddFlight(createdModel));

            //act            
            var result = _flightController.Create(createdModel) as RedirectToActionResult;

            //assert           
            Assert.True(result != null);;
            Assert.Equal("Index", result.ActionName);
        }
    }
}
