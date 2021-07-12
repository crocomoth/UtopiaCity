using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport
{
    /// <summary>
    /// Represents report about weather
    /// </summary>
    public class WeatherReport
    {
        public string Id { get; set; }
        public DateTime Days { get; set; }
        public string WeatherCondition { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Rainfall { get; set; }
        public string Moisture { get; set; }
    }
}
