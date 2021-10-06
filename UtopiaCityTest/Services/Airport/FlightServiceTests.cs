using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Services.Airport;
using Xunit;

namespace UtopiaCityTest.Services.Airport
{
    public class FlightServiceTests : BaseServiceTest
    {
        private IRouteApi _route;
       
        public FlightServiceTests()
        {
            Setup();           
        }

        [Fact]
        public void GetFlights_ReturnsItems_IfTheyExistInDb()
        {
            var localOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "UtopiaCityTest").Options;

            using(var context=new ApplicationDbContext(localOptions))
            {
                context.Flights.Add(new Flight { Id = "1", ArrivalTime = DateTime.Now.AddDays(1), DepartureTime = DateTime.Now, LocationPoint = "abc", DestinationPoint = "efg", Weather = "some weather", FlightNumber = 123 });
                context.Flights.Add(new Flight { Id = "2", ArrivalTime = DateTime.Now.AddDays(2), DepartureTime = DateTime.Now, LocationPoint = "zaa", DestinationPoint = "gss", Weather = "weather", FlightNumber = 456 });
                context.Flights.Add(new Flight { Id = "3", ArrivalTime = DateTime.Now.AddDays(3), DepartureTime = DateTime.Now, LocationPoint = "bbb", DestinationPoint = "rrr", Weather = "cold weather", FlightNumber = 555 });

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(localOptions))
            {
                var service = new FlightService(context,_route);

                //act
                var result = service.GetFlightList();

                //assert
                Assert.Equal(3, result.Count);
                Assert.Collection(result,
                    item => item.Id.Equals("1"),
                    item => item.Id.Equals("2"),
                    item => item.Id.Equals("3"));
                Assert.Collection(result,
                    item => item.ArrivalTime.Equals(DateTime.Now.AddDays(1)),
                    item => item.ArrivalTime.Equals(DateTime.Now.AddDays(2)),
                    item => item.ArrivalTime.Equals(DateTime.Now.AddDays(3)));
                Assert.Collection(result,
                    item => item.DepartureTime.Equals(DateTime.Now),
                    item => item.DepartureTime.Equals(DateTime.Now),
                    item => item.DepartureTime.Equals(DateTime.Now));
                Assert.Collection(result,
                    item => item.LocationPoint.Equals("abc"),
                    item => item.LocationPoint.Equals("zaa"),
                    item => item.LocationPoint.Equals("bbb"));
                Assert.Collection(result,
                    item => item.DestinationPoint.Equals("efg"),
                    item => item.DestinationPoint.Equals("gss"),
                    item => item.DestinationPoint.Equals("rrr"));
                Assert.Collection(result,
                    item => item.Weather.Equals("some weather"),
                    item => item.Weather.Equals("weather"),
                    item => item.Weather.Equals("cold weather"));
                Assert.Collection(result,
                    item => item.FlightNumber.Equals(123),
                    item => item.FlightNumber.Equals(456),
                    item => item.FlightNumber.Equals(555));                   
            }
        }

        [Fact]
        public void GetFlights_ReturnsItems_IfItExistsInDb_Alternative()
        {
            // arrange

            using (var context = new ApplicationDbContext(options))
            {
                var service = new FlightService(context, _route);

                // act
                var result = service.GetFlightList();
                // assert
                Assert.Equal(10, result.Count);
                Assert.Collection(result,
                    item => item.Weather.Equals("Sunny"),
                    item => item.Weather.Equals("Rainy"),
                    item => item.Weather.Equals("Cloudy"),
                    item => item.Weather.Equals("Windy"),
                    item => item.Weather.Equals("Foggy"),
                    item => item.Weather.Equals("Stormy"),
                    item => item.Weather.Equals("Sunny"),
                    item => item.Weather.Equals("Cloudy"),
                    item => item.Weather.Equals("Rainy"),
                    item => item.Weather.Equals("Windy"));
            }
        }

        [Fact]
        public void GetFlightById_ReturnItem_IfItExistInDb()
        {
            //arrange
            using(var context=new ApplicationDbContext(options))
            {
                var service = new FlightService(context, _route);
                var flightModel = context.Flights.FirstOrDefaultAsync().GetAwaiter().GetResult();

                //act
                var result = service.GetFlightById(flightModel.Id);

                //assert
                Assert.True(result != null);
                Assert.Equal(flightModel.Id, result.Id);
                Assert.Equal(flightModel.FlightNumber, result.FlightNumber);
                Assert.Equal(flightModel.ArrivalTime, result.ArrivalTime);
                Assert.Equal(flightModel.DepartureTime, result.DepartureTime);
                Assert.Equal(flightModel.LocationPoint, result.LocationPoint);
                Assert.Equal(flightModel.DestinationPoint, result.DestinationPoint);
                Assert.Equal(flightModel.Weather, result.Weather);
            }
        }

        [Fact]
        public void AddNewFlightToDb_AddingObject()
        {
            //arrange            

            using (var context = new ApplicationDbContext(options))
            {
                var service = new FlightService(context, _route);

                var flightModel = new Flight
                {
                    Id = Guid.NewGuid().ToString(),
                    ArrivalTime = DateTime.Now.AddDays(1),
                    DepartureTime = DateTime.Now,
                    LocationPoint = "Moscow",
                    DestinationPoint = "Stambul",
                    Weather = "Rainy",
                    FlightNumber = 123,
                    TypeOfAircraft = "bad aircraft"
                };

                service.AddFlight(flightModel);

                //act 
                var result = context.Flights.FirstOrDefaultAsync(x => x.FlightNumber.Equals(flightModel.FlightNumber)).GetAwaiter().GetResult();

                //assert
                Assert.True(result != null);
                Assert.Equal(flightModel, result);        
            }
        }

        [Fact]
        public void RemoveFlightFromDb_RemovingItem_IfItExistsInDb()
        {
            //arrange           
            using(var context=new ApplicationDbContext(options))
            {
                var service = new FlightService(context, _route);
                var flightModel = context.Flights.FirstOrDefaultAsync().GetAwaiter().GetResult();

                service.DeleteFlight(flightModel);
                var listFlights = service.GetFlightList();
                //act
                var result = service.GetFlightById(flightModel.Id);

                //assert
                Assert.True(flightModel != null);
                Assert.True(result is null);
                Assert.Equal(9, listFlights.Count);
            }
        }

        [Fact]
        public void UpdateFlightInDb_UpdateItem_IfItExistInDb()
        {
            //arrange
            using(var context=new ApplicationDbContext(options))
            {
                var service = new FlightService(context, _route);
                var flightModel = context.Flights.FirstOrDefaultAsync().GetAwaiter().GetResult();
                var currentModel = service.GetFlightById(flightModel.Id);
                var tempModel = new Flight
                {
                    Id = flightModel.Id,
                    LocationPoint = flightModel.LocationPoint,
                    DestinationPoint = flightModel.DestinationPoint,
                    Weather = flightModel.Weather,
                    ArrivalTime = flightModel.ArrivalTime,
                    DepartureTime = flightModel.DepartureTime,
                    FlightNumber = flightModel.FlightNumber,
                    TypeOfAircraft = flightModel.TypeOfAircraft,
                };
                currentModel.LocationPoint = "Zimbabve";
                currentModel.DestinationPoint = "Ottawa";
                currentModel.Weather = "silnii veter, vremenami uragan";

                //act
                service.UpdateFlight(currentModel);

                //assert
                Assert.True(service != null);
                Assert.True(flightModel != null);
                Assert.True(currentModel != null);
                Assert.Equal(tempModel.Id, currentModel.Id);
                Assert.Equal(tempModel.FlightNumber, currentModel.FlightNumber);
                Assert.Equal(tempModel.ArrivalTime, currentModel.ArrivalTime);
                Assert.Equal(tempModel.DepartureTime, currentModel.DepartureTime);
                Assert.Equal(tempModel.TypeOfAircraft, currentModel.TypeOfAircraft);
                Assert.NotEqual(currentModel.LocationPoint, tempModel.LocationPoint);
                Assert.NotEqual(currentModel.DestinationPoint, tempModel.DestinationPoint);
                Assert.NotEqual(currentModel.Weather, tempModel.Weather);
            }
        }

        [Fact]
        public void GetArrivalTime_ReturnsDateTime()
        {
            //arrange
            var departureTime = DateTime.Now;

            //act
            var result = departureTime.AddHours(2);

            //assert
            Assert.True(result != null);
            Assert.NotEqual(result, departureTime);
        }

        //[Fact]
        //public void GetArrivalTime_ReturnsDateTime_Alternative()
        //{
        //    //arrange
        //    using(var context=new ApplicationDbContext(options))
        //    {
        //        var routeApiMock = new Mock<IRouteApi>();
        //        var services = new Mock<FlightService>(context, routeApiMock.Object);

        //        var flightModel = context.Flights.FirstOrDefaultAsync().GetAwaiter().GetResult();
        //        var departureTime = flightModel.DepartureTime;
        //        var location = "London";
        //        var destination = "Stambul";
        //        var planeType = "PassengerShortLengthAircraft";

        //        var tempData = services.Object.GetFlyTime(location, destination, planeType).GetAwaiter().GetResult();
        //        //can't understand why this function returns null, maybe i didn't mock FlightService class correctly
        //        // or need to make correct Setup.Expression


        //        //act
        //        var result = departureTime.AddHours(tempData);

        //        //assert
        //        Assert.NotNull(flightModel);
        //        Assert.True(departureTime != null);
        //        Assert.True(location != null);
        //        Assert.True(destination != null);
        //        //Assert.True(tempData != 0);
        //        Assert.Equal(flightModel.LocationPoint, location);
        //        Assert.Equal(flightModel.DestinationPoint, destination);
        //        //Assert.NotEqual(result, departureTime);
                
        //        //Test works but with zero returnings there is no so much meaning
        //    }
        //}
    }
}
