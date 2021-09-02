using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.FireSystem
{
    public class FireSafetyCheck
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Address { get; set; }
        public string ObjectName { get; set; }
        public bool FireSafetyDocuments { get; set; }
        public bool FireFightingEquipment { get; set; }
        public bool Journals { get; set; }
        public bool FireSafetySigns { get; set; }
        public bool EscapeRoutes { get; set; }
        public bool SmokingAreas { get; set; }
    }
}
