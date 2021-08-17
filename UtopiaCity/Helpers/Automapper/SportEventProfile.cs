using AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Helpers.AutoMapper
{
    public class SportEventProfile : Profile
    {
        public SportEventProfile()
        {
            CreateMap<SportEvent, SportEventViewModel>()
                .ForMember(dest => dest.SportEventTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.SportComplexTitle, opt => opt.MapFrom(src => src.SportComplex.Title))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.SportComplex.Address));

            CreateMap<SportEventViewModel, SportEvent>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.SportEventTitle));
        }
    }
}