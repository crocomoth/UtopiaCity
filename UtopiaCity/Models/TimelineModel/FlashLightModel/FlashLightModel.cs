using System;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Models.TimelineModel.FlashLightModel
{
    public class FlashLightModel
    {
        [Required(ErrorMessage = "Поле сезона года")]
        public string Season { get; set; }

        [Required(ErrorMessage = "Дата")]
        public DateTime DateValue { get; set; }

        public WeatherReport weatherReport { get; set; }
    }
}
