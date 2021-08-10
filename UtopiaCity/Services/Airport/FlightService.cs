using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    /// <summary>
    ///  Class to handle basic CRUD operations for <see cref="Flight"/>
    /// </summary>
    public class FlightService
    {
        private ApplicationDbContext _dbContext;
        private readonly IRouteApi _route;
        public FlightService(ApplicationDbContext context,IRouteApi route)
        {
            _dbContext = context;
            _route = route;
        }

        /// <summary>
        /// Gets list of all flights
        /// </summary>
        /// <returns>List of flights</returns>
        public List<Flight> GetFlightList()
        {
            return _dbContext.Flights.ToList();
        }

        /// <summary>
        /// Gets flight by Id
        /// </summary>
        /// <param name="id">Flights' Id</param>
        /// <returns>Special flight if exist, otherwise null</returns>
        public Flight GetFlightById(string id)
        {
            return _dbContext.Flights.FirstOrDefault(x => x.Id.Equals(id));
        } 

        /// <summary>
        /// Create a new flight, by adding it to the database
        /// </summary>
        /// <param name="newflight">New flight</param>
        public void AddFlight(Flight newflight)
        {
            _dbContext.Add(newflight);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update existing flight
        /// </summary>
        /// <param name="editedFlight">Existing flight</param>
        public void UpdateFlight(Flight editedFlight)
        {
            _dbContext.Update(editedFlight);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Remove flight from database
        /// </summary>
        /// <param name="currentFlight">Flight to remove</param>
        public void DeleteFlight(Flight currentFlight)
        {
            _dbContext.Remove(currentFlight);
            _dbContext.SaveChanges();
        }

        /// <summary>
        ///  Set the unique Flight Number
        /// </summary>
        /// <returns>Random integer value</returns>
        public int GetRandomFlightNumber()
        {
            return new Random().Next(100, 999);
        }

        public async Task<double> GetFlyTime(string location, string destination, string planeType)
        {
            var resources = await _route.GetRouteObject(location, destination);
            var generalDistance = resources.ElementAtOrDefault(0).TravelDistance;
            var fromDictionary = new Dictionaries.PlanesSpeedDictionary().speed;
            double generalFlyTime = 0;

            foreach(var item in fromDictionary)
            {
                if (item.Key == planeType)
                {
                    generalFlyTime = generalDistance / item.Value;
                }
            }

            return generalFlyTime;
        }

        public DateTime GetArrivalTime(DateTime departure, string locationPoint,string destinationPoint,string planeType)
        {
            var overallTime= departure.AddHours(GetFlyTime(locationPoint, destinationPoint, planeType).GetAwaiter().GetResult());
            return overallTime;
        }
    }
}
