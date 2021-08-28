using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Airport
{
    public class ArrivingPassenger
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string PassengerFirstName { get; set; }
        public string PassengerFamilyName { get; set; }
        public DateTime PassengerBirthDate { get; set; }
        public string PassengerGender { get; set; }
        public string PassengerStatus { get; set; }
        public string PassengerMarriageStatus { get; set; }
    }
}
