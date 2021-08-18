using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Models.Airport
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FlightId { get; set; }
        public string PermitedModelId { get; set; }
        public string ResidentAccountId { get; set; }
        public string Direction { get; set; }

        public Flight Flight { get; set; }
        public PermitedModel PermitedModel { get; set; }
        public ResidentAccount ResidentAccount { get; set; }
    }
}
