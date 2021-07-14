using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="WeatherReport"/>
    /// </summary>
    public class WeatherReportService
    {
        private readonly ApplicationDbContext _dbContext;

        public WeatherReportService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Gets the whole list of weather reports
        /// </summary>
        /// <returns>List of reports</returns>
        public List<WeatherReport> GetWeatherReportsList()
        {
            return _dbContext.WeatherReports.ToList();
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
        /// Checks if requested datetime exist or not
        /// </summary>
        /// <param name="reportTime">Model to check</param>
        /// <returns>Requested model otherwise null</returns>
        public WeatherReport GetReportDateTimeValidation(WeatherReport reportTime)
        {
            var specialReport= _dbContext.WeatherReports.FirstOrDefault(x => x.Days.Equals(reportTime.Days));
            if (specialReport is null)
            {
                return reportTime;
            }
            else
            {
                return null;
            }            
        }
    }
}
