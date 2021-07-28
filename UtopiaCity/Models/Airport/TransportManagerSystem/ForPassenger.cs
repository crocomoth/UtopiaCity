using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Airport.TransportManagerSystem
{
    public class ForPassenger
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public string TransportType { get; set; }
        public string Address { get; set; }
        public string PayType { get; set; }
    }
}