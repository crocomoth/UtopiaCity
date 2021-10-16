using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.ViewModels.FireSystem
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Сhief { get; set; }
        public DepartmentStatusEnum DepartmentStatusEnum { get; set; }

        //public string TypeOfFireCar { get; set; }
        //public ICollection<EmployeeManagement> Employees { get; set; }
        //public List<TransportManagement> Transports { get; set; }
        //public ICollection<DepartureToThePlaceOfFire> DepartureToThePlaces { get; set; }
    }
}
