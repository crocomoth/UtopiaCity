using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Emergency
{
    public class EmergencyReport
    {
        public string Id { get; set; }
        public string Report { get; set; }
        public DateTime ReportTime { get; set; }
    }
}
