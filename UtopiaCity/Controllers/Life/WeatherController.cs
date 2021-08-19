using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Helpers.WeatherReportApi;

namespace UtopiaCity.Controllers.Life
{
    public class WeatherController : Controller
    {
        private readonly IMapper _mapper;
        public WeatherController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("flightreports")]
        public async Task<List<UtopiaCity.Models.Airport.WeatherReport>> GetFlightWeatherReports()
        {
            var data = await WeatherReportApi.Get30DayReportAsync();
            if (data != null)
            {
                return _mapper.Map<List<UtopiaCity.Models.Airport.WeatherReport>>(data);
            }
            else
            {
                return null;
            }
        }
        [HttpPost("flightreport")]
        public async Task<UtopiaCity.Models.Airport.WeatherReport> GetFlightWeatherReport(DateTime date)
        {
            if (date != null)
            {
                var data = await WeatherReportApi.GetReportClosestToDateAsync(date);
                if (data != null)
                {
                    return _mapper.Map<Models.Airport.WeatherReport>(data);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
