using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.ViewModels.HousingSystem;

namespace UtopiaCity.Helpers.Automapper
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            CreateMap<RealEstate, AddRealEstateViewModel>()
                .ForMember(dest => dest.CompletionYear, opt => opt.MapFrom(src => src.CompletionYear))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.ResidentAccount, opt => opt.MapFrom(src => src.ResidentAccount))
                .ForMember(dest => dest.EstateType, opt => opt.MapFrom(src => src.EstateType))
                //.ForMember(dest => dest.Residents, opt => opt.MapFrom(src => src.Residents))
                .ReverseMap();
        }
    }
}
