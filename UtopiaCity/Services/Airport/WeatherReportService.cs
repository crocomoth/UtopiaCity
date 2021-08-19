using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Helpers.Automapper;
using UtopiaCity.Helpers.WeatherReportApi;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Services.Airport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="WeatherReport"/>
    /// </summary>
    public class WeatherReportService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WeatherReportService(ApplicationDbContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the whole list of weather reports
        /// </summary>
        /// <returns>List of reports</returns>
        public List<WeatherReport> GetWeatherReportsList()
        {
            return _dbContext.WeatherReports.Include(x => x.PermitedModel).ToList();
        }

        /// <summary>
        /// Gets the special report by special id
        /// </summary>
        /// <param name="id">Reports id</param>
        /// <returns>Whole report</returns>
        public WeatherReport GetWeatherReportById(string id)
        {
            return _dbContext.WeatherReports.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Adds reports
        /// </summary>
        /// <param name="newReport">Report to add</param>
        public void CreateWeatherReport(WeatherReport newReport)
        {
            _dbContext.Add(newReport);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="editedReport">Existing report to update</param>
        public void UpdateWeatherReport(WeatherReport editedReport)
        {
            _dbContext.Update(editedReport);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removing the report from the database
        /// </summary>
        /// <param name="currentReport">Report to remove</param>
        public void DeleteWeatherReport(WeatherReport currentReport)
        {
            _dbContext.Remove(currentReport);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets Weather data report permission by using DateTime
        /// </summary>
        /// <param name="currentDate">DateTime to use</param>
        /// <returns>Existing permission of Boolean type</returns>
        public bool GetPermitedWeatherReport(DateTime currentDate)
        {
            var weatherData = WeatherReportApi.GetReportClosestToDateAsync(currentDate).GetAwaiter().GetResult();
            if(weatherData != null)
            {
               var mappedData= _mapper.Map<WeatherReport>(weatherData);
               return GetPermissionByWeatherConditions(mappedData);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Additional method for validating data from third-party-api and context
        /// </summary>
        /// <param name="weatherData">Object to map for</param>
        /// <returns>Bool : True if properties match conditions, otherwise false </returns>
        private bool GetPermissionByWeatherConditions(WeatherReport weatherData)
        {
            var mappedApiData = _mapper.Map<PermitedModel>(weatherData);
            var dataFromContext = _dbContext.PermitedModel.FirstOrDefault();

            static int? NullableTryParseInt(string someString)
            {
                int value;
                return int.TryParse(someString, out value) ? (int?)value : null;
            }

            var speedOfWindApi = NullableTryParseInt(mappedApiData.SpeedOfWind);
            var speedOfWindContext = NullableTryParseInt(dataFromContext.SpeedOfWind);
            if (speedOfWindApi > speedOfWindContext)
            {
                return false;
            }

            var rainfallApi = NullableTryParseInt(mappedApiData.Rainfall);
            var rainfallContext = NullableTryParseInt(dataFromContext.Rainfall);
            if (rainfallApi > rainfallContext)
            {
                return false;
            }

            else
            {
                return true;
            }

            //ToDo: Refactoring,
            //Add more properties, 
            //Create better validation
        }
    }
}
