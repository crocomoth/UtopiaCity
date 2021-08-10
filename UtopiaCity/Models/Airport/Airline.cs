using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Airport
{
    public class Airline
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string AirlineName { get; set; }
        public string ServiceType { get; set; }
        public string Aircraft { get; set; }
        public string AvailableDirections { get; set; }
    }
}
