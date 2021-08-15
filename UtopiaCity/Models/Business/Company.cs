using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Business
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string CEO { get; set; }  // <----
        
        public string IIK { get; set; }

        public string BIN { get; set; }

        public string BankId { get; set; }
        public Bank Bank { get; set; }

        public string CompanyStatusId { get; set; }
        public CompanyStatus CompanyStatus { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
