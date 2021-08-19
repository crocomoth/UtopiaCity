using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport.TransportManagerSystem
{
    public class ForCompany
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string CompanyName { get; set; }
        public string Contacts { get; set; }
        public string AviaProvider { get; set; }
        public string CountryOfDelivery { get; set; }
        public string QuantityOfGoods { get; set; }
        public string WaitingTime { get; set; }
    }
}
