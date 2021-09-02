using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees
{
    public class EmployeeManagement
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Equipment { get; set; } //enum
    }
}
