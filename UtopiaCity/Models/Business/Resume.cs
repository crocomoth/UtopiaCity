using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Models.Business
{
    public class Resume
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string ResidentAccountId { get; set; }
        public ResidentAccount ResidentAccount { get; set; }
        public string ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public int Salary { get; set; }
        public DateTime? WorkExperienceDateStart { get; set; }
        public DateTime? WorkExperienceDateEnd { get; set; }
        public bool UntilNow { get; set; }
    }
}
