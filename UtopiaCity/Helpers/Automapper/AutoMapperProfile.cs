using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Helpers.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UtopiaCity.Models.Life.WeatherReport.Data, UtopiaCity.Models.Airport.WeatherReport>()
                       .ForMember(destination => destination.Id,
                       map => map.MapFrom(source => Guid.NewGuid().ToString()))
                       .ForMember(destination => destination.Moisture,
                       map => map.MapFrom(source => source.Main.Humidity))
                       .ForMember(destination => destination.Rainfall,
                       map => map.MapFrom(source => source.Rain != null ? "Rain" : "No rain"))
                       .ForMember(destination => destination.Temperature,
                       map => map.MapFrom(source => source.Main.Temperature))
                       .ForMember(destination => destination.WeatherCondition,
                       map => map.MapFrom(source => source.Weather.FirstOrDefault().Descriprion))
                       .ForMember(destination => destination.Wind,
                       map => map.MapFrom(source => source.Wind.Speed.ToString()))
                       .ForMember(destination => destination.FlightWeather,
                       map => map.MapFrom(source => ""));

            CreateMap<WeatherReport, PermitedModel>()
                       .ForMember(destination => destination.PermissionStatus,
                       map => map.MapFrom(source => source.FlightWeather))
                       .ForMember(destination => destination.SpeedOfWind,
                       map => map.MapFrom(source => source.Wind))
                       .ForMember(destination => destination.Rainfall,
                       map => map.MapFrom(source => source.Rainfall));

            CreateMap<ArrivingPassenger, ResidentAccount>()
                       .ForMember(destination => destination.FirstName,
                       map => map.MapFrom(source => source.PassengerFirstName))
                       .ForMember(destination => destination.FamilyName,
                       map => map.MapFrom(source => source.PassengerFamilyName))
                       .ForMember(destination => destination.BirthDate,
                       map => map.MapFrom(source => source.PassengerBirthDate))
                       .ForMember(destination => destination.Gender,
                       map => map.MapFrom(source => source.PassengerGender))
                       .ForMember(destination => destination.Marriage,
                       map => map.MapFrom(source => source.PassengerMarriageStatus));
        }
    }
}
