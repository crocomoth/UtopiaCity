using AutoMapper;
using System;
using UtopiaCity.Models.Media;
using UtopiaCity.Models.Media.Account;
using UtopiaCity.Models.Media.Responses;

namespace UtopiaCity.Helpers.Automapper
{
    public class Media : Profile
    {
        public Media()
        {
            CreateMap<User, AuthenticateResponse>()
                       .ForMember(expr => expr.Email,
                       map => map.MapFrom(expr => expr.Email))
                       .ForMember(expr => expr.Role,
                       map => map.MapFrom(expr => expr.Role))
                       .ForMember(x => x.FName,
                       map => map.MapFrom(x => x.FirstName))
                       .ForMember(x => x.LName,
                       map => map.MapFrom(x => x.LastName));

            CreateMap<Employee, AuthenticateResponse>()
                       .ForMember(expr => expr.Email,
                       map => map.MapFrom(expr => expr.Email))
                       .ForMember(expr => expr.Role,
                       map => map.MapFrom(expr => expr.Role))
                       .ForMember(x => x.FName,
                       map => map.MapFrom(x => x.FirstName))
                       .ForMember(x => x.LName,
                       map => map.MapFrom(x => x.LastName));

            CreateMap<RegisterRequest, User>()
                       .ForMember(expr => expr.Email,
                       map => map.MapFrom(expr => expr.Email))
                       .ForMember(expr => expr.PasswordHash,
                       map => map.MapFrom(expr => expr.Password))
                       .ForMember(x => x.FirstName,
                       map => map.MapFrom(x => x.FName))
                       .ForMember(x => x.LastName,
                       map => map.MapFrom(x => x.LName))
                       .ForMember(x => x.RegistrationDate,
                       map => map.MapFrom(x => DateTime.UtcNow));

            CreateMap<User, RegisterResponse>()
                       .ForMember(expr => expr.Email,
                       map => map.MapFrom(expr => expr.Email))
                       .ForMember(expr => expr.Role,
                       map => map.MapFrom(expr => expr.Role));

        }
    }
}


