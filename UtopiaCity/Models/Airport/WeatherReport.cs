using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Models.Airport
{
    /// <summary>
    /// Represents report about weather
    /// </summary>
    public class WeatherReport
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string WeatherCondition { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Rainfall { get; set; }
        public string Moisture { get; set; }
        public string FlightWeather { get; set; }
        public string DirectionFrom { get; set; }
        public string DirectionTo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PermitedModelId { get; set; }

        public PermitedModel PermitedModel { get; set; }
    }
}
