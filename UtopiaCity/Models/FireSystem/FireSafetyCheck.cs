using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Models.FireSystem
{
    public class FireSafetyCheck
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required, MaxLength(25)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string ObjectName { get; set; }
        public bool FireSafetyDocuments { get; set; }
        public bool FireFightingEquipment { get; set; }
        public bool Journals { get; set; }
        public bool FireSafetySigns { get; set; }
        public bool EscapeRoutes { get; set; }
        public bool SmokingAreas { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public EmployeeManagement Employee { get; set; }
    }
}
