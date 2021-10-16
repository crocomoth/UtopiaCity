using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;
using UtopiaCity.ViewModels.FireSystem;

namespace UtopiaCity.Helpers.Automapper
{
    public class EmployeeManagementProfile : Profile
    {
        public EmployeeManagementProfile()
        {
            CreateMap<EmployeeManagement, EmployeeManagementViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CanCheck, opt => opt.MapFrom(src => src.CanCheck))
                .ForMember(dest => dest.EmployeePosition, opt => opt.MapFrom(src => src.EmployeePosition))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ReverseMap();
        }
    }
}
