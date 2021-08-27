using System;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportTicketViewModel
    {
        public string SportTicketId { get; set; }
        public string SportComplexTitle { get; set; }
        public string Address { get; set; }
        public string SportEventTitle { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public string VisitorName { get; set; }
        public string VisitorSurname { get; set; }
    }
}
