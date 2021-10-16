using AutoMapper;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;
using UtopiaCity.ViewModels.FireSystem;

namespace UtopiaCity.Helpers.Automapper
{
    public class TransportManagementProfile : Profile
    {
        public TransportManagementProfile()
        {
            CreateMap<TransportManagement, TransportManagementViewModel>()
                .ForMember(dest => dest.TypeOfFireCar, opt => opt.MapFrom(src => src.TypeOfFireCar))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.FirePump, opt => opt.MapFrom(src => src.FirePump))
                .ForMember(dest => dest.ContainerForStoringFireExtinguishingAgents, opt => opt.MapFrom(src => src.ContainerForStoringFireExtinguishingAgents))
                .ForMember(dest => dest.FireFightingEquipment, opt => opt.MapFrom(src => src.FireFightingEquipment))
                .ReverseMap();
        }
    }
}
