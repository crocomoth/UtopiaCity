using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport.TransportManagerSystem
{
    public class TransportManager
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }       

        public string TypeOfOrder { get; set; }
        
        public string ForPassengerId { get; set; }
        public ForPassenger ForPassenger { get; set; }

        public string ForCompanyId { get; set; }
        public ForCompany ForCompany { get; set; }
    }
}
