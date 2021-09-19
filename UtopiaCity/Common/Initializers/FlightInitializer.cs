using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Utils;

namespace UtopiaCity.Common.Initializers
{
    public class FlightInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Flights.Any())
            {
                return;
            }

            context.RemoveRange(context.Flights.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Flights.Any())
            {
                return;
            }
            var flight1 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(4),
                DepartureTime = DateTime.Now,
                LocationPoint = "Moscow",
                DestinationPoint = "Stambul",
                Weather = "Sunny"
            };
            var flight2 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(1),
                LocationPoint = "Moscow",
                DestinationPoint = "Madrid",
                Weather = "Rainy"
            };
            var flight3 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(5),
                DepartureTime = DateTime.Now,
                LocationPoint="Madrid",
                DestinationPoint = "Stambul",
                Weather = "Cloudy"
            };
            var flight4 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(7),
                DepartureTime = DateTime.Now.AddHours(2),
                LocationPoint="Moscow",
                DestinationPoint = "Dubai",
                Weather = "Windy"
            };
            var flight5 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(3),
                LocationPoint="Stambul",
                DestinationPoint = "London",
                Weather = "Foggy"
            };
            var flight6 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(7),
                DepartureTime = DateTime.Now.AddHours(3),
                LocationPoint = "Madrid",
                DestinationPoint = "London",
                Weather = "Stormy"
            };
            var flight7 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(7),
                DepartureTime = DateTime.Now.AddHours(2),
                LocationPoint = "Dubai",
                DestinationPoint = "Stambul",
                Weather = "Sunny"
            };
            var flight8 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(9),
                DepartureTime = DateTime.Now.AddHours(5),
                LocationPoint = "Dubai",
                DestinationPoint = "London",
                Weather = "Cloudy"
            };
            var flight9 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(9),
                DepartureTime = DateTime.Now.AddHours(4),
                LocationPoint = "London",
                DestinationPoint = "Moscow",
                Weather = "Rainy"
            };
            var flight10 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomThreePointInteger(),
                ArrivalTime = DateTime.Now.AddHours(5),
                DepartureTime = DateTime.Now.AddHours(1),
                LocationPoint = "London",
                DestinationPoint = "Dubai",
                Weather = "Windy"
            };

            context.AddRange(flight1, flight2, flight3, flight4, flight5, flight6, flight7, flight8, flight9, flight10);
            context.SaveChanges();
        }
    }
}
