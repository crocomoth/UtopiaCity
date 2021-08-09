using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Life.WeatherReport
{
    public class LifeWeatherReport
    {
        [JsonProperty("cod")]
        public string Code { get; set; }
        [JsonProperty("list")]
        public List<Data> Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty("visibility")]
        public double Visibility { get; set; }
        [JsonProperty("dt_txt")]
        public DateTime Date { get; set; }
        [JsonProperty("rain")]
        public Rain? Rain { get; set; }

    }
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
    }
    public class Weather
    {        
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Descriprion { get; set; }
    }
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Degree { get; set; }
        [JsonProperty("gust")]
        public double Gust { get; set; }
    }
    public class Rain
    {
        public double ThreeH { get; set; }
    }
}
