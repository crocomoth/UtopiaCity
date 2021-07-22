using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

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
                FlightNumber = 128,
                ArrivalTime = DateTime.Now.AddHours(4),
                DepartureTime = DateTime.Now,
                Destination = "Moscow,Russia",
                Weather = "Sunny"
            };
            var flight2 = new Flight()
            {
                FlightNumber = 256,
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(1),
                Destination = "Madrid,Spain",
                Weather = "Rainy"
            };
            var flight3 = new Flight()
            {
                FlightNumber = 512,
                ArrivalTime = DateTime.Now.AddHours(5),
                DepartureTime = DateTime.Now,
                Destination = "Stambul,Turkey",
                Weather = "Cloudy"
            };
            var flight4 = new Flight()
            {
                FlightNumber = 223,
                ArrivalTime = DateTime.Now.AddHours(7),
                DepartureTime = DateTime.Now.AddHours(2),
                Destination = "Dubai,UAE",
                Weather = "Windy"
            };
            var flight5 = new Flight()
            {
                FlightNumber = 876,
                ArrivalTime = DateTime.Now.AddHours(13),
                DepartureTime = DateTime.Now.AddHours(3),
                Destination = "London,UK",
                Weather = "Foggy"
            };

            context.AddRange(flight1, flight2, flight3, flight4, flight5);
            context.SaveChanges();
        }
    }
}
