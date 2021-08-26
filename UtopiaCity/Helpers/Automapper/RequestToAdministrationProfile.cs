using AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Helpers.Automapper
{
    public class RequestToAdministrationProfile : Profile
    {
        public RequestToAdministrationProfile()
        {
            CreateMap<RequestToAdministration, RequestToAdministrationViewModel>()
                .ForMember(dest => dest.SportComplexTitle, opt => opt.MapFrom(src => src.SportComplex.Title))
                .ForMember(dest => dest.TypeOfSport, opt => opt.MapFrom(src => src.SportComplex.TypeOfSport))
                .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.SportComplex.Available));

            CreateMap<RequestToAdministrationViewModel, RequestToAdministration>();
        }
    }
}
