using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Business
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FIO { get; set; }

        public string ProfessionId { get; set; }

        public Profession Profession { get; set; }

        public int Salary { get; set; }
        
        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
