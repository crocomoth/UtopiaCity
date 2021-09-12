using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    public class CheckedFlightService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CheckedFlightService(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<CheckedFlight> GetCheckedFlightList()
        {
            return _dbContext.CheckedFlights.ToList();
        }

        public CheckedFlight GetCheckedFlightById(string id)
        {
            return _dbContext.CheckedFlights.FirstOrDefault(x => x.Id.Equals(id));
        }

        public CheckedFlight CheckFlightByWeatherReport(Flight flight)
        {
            var mappedObj = _mapper.Map<CheckedFlight>(flight);
            var weatherReportFrom = _dbContext.WeatherReports.FirstOrDefault(x => x.DirectionFrom.Equals(flight.LocationPoint));          
            if(weatherReportFrom != null)
            {
                mappedObj.CheckedFlightWeather = weatherReportFrom.FlightWeather;
            }        

            return mappedObj;
        }

        public void AddCheckedFlight(CheckedFlight checkedModel)
        {
            _dbContext.Add(checkedModel);
            _dbContext.SaveChanges();
        }

        public void DeleteCheckedFlight(CheckedFlight modelToRemove)
        {
            _dbContext.Remove(modelToRemove);
            _dbContext.SaveChanges();
        }
    }
}
