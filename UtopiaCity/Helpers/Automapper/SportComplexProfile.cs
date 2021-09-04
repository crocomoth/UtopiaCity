using AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Helpers.AutoMapper
{
    public class SportComplexProfile : Profile
    {
        public SportComplexProfile()
        {
            CreateMap<SportComplex, SportComplexViewModel>()
                .ForMember(dest => dest.SportComplexTitle, opt => opt.MapFrom(src => src.Title))
                .ReverseMap();
        }
    }
}