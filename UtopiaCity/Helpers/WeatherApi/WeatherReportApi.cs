using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UtopiaCity.Helpers.Automapper;
using UtopiaCity.Models.Life.WeatherReport;

namespace UtopiaCity.Helpers.WeatherReportApi
{
    //thir party api to fetch weather data
    public class WeatherReportApi
    {
        private const string _url = "http://api.openweathermap.org/data/2.5/forecast?id=1526384&units=metric&appid=5b98e225e9b8afbfa5fb5b1cf47fcffe";
        public static async Task<List<UtopiaCity.Models.Life.WeatherReport.Data>> Get30DayReportAsync()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LifeWeatherReport>(json).Data;
                }
                else
                {
                    return null;
                }
            }
        }
        public static async Task<UtopiaCity.Models.Life.WeatherReport.Data> GetReportClosestToDateAsync(DateTime date)
        {
            var list = await Get30DayReportAsync();
            if (list != null)
            {
                var nearestDiff = list.Min(x => Math.Abs((x.Date - date).Ticks));
                return list.Where(x => Math.Abs((x.Date - date).Ticks) == nearestDiff).First();
            }
            else
            {
                return null;
            }
        }        
    }
}
