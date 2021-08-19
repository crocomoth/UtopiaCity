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
                FlightNumber = RandomUtil.GenerateRandomString(200).ElementAt(1),
                ArrivalTime = DateTime.Now.AddHours(4),
                DepartureTime = DateTime.Now,
                LocationPoint = "Moscow",
                DestinationPoint = "Stambul",
                Weather = "Sunny"
            };
            var flight2 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomString(100).ElementAt(2),
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(1),
                LocationPoint = "Moscow",
                DestinationPoint = "Madrid",
                Weather = "Rainy"
            };
            var flight3 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomString(150).ElementAt(4),
                ArrivalTime = DateTime.Now.AddHours(5),
                DepartureTime = DateTime.Now,
                LocationPoint="Madrid",
                DestinationPoint = "Stambul",
                Weather = "Cloudy"
            };
            var flight4 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomString(300).ElementAt(26),
                ArrivalTime = DateTime.Now.AddHours(7),
                DepartureTime = DateTime.Now.AddHours(2),
                LocationPoint="Moscow",
                DestinationPoint = "Dubai",
                Weather = "Windy"
            };
            var flight5 = new Flight()
            {
                FlightNumber = RandomUtil.GenerateRandomString(150).ElementAt(54),
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(3),
                LocationPoint="Stambul",
                DestinationPoint = "London",
                Weather = "Foggy"
            };

            context.AddRange(flight1, flight2, flight3, flight4, flight5);
            context.SaveChanges();
        }
    }
}
