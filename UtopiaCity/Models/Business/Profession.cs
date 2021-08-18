using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Business
{
    public class Profession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
