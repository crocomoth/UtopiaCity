using AutoMapper;
using UtopiaCity.Models.Sport;
using UtopiaCity.ViewModels.Sport;

namespace UtopiaCity.Helpers.Automapper
{
    public class SportTicketProfile : Profile
    {
        public SportTicketProfile()
        {
            CreateMap<SportTicket, SportTicketViewModel>()
                .ForMember(dist => dist.SportTicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dist => dist.SportComplexTitle, opt => opt.MapFrom(src => src.SportComplex.Title))
                .ForMember(dist => dist.SportEventTitle, opt => opt.MapFrom(src => src.SportEvent.Title))
                .ForMember(dist => dist.Address, opt => opt.MapFrom(src => src.SportComplex.Address))
                .ForMember(dist => dist.DateOfTheEvent, opt => opt.MapFrom(src => src.SportEvent.DateOfTheEvent))
                .ForMember(dist => dist.VisitorName, opt => opt.MapFrom(src => src.AppUser.Name))
                .ForMember(dist => dist.VisitorSurname, opt => opt.MapFrom(src => src.AppUser.Surname));

            CreateMap<SportTicketViewModel, SportTicket>()
                .ForMember(dist => dist.TicketId, opt => opt.MapFrom(src => src.SportTicketId));
        }
    }
}
