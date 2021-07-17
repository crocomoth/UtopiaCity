using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Sport.ViewModels
{
    public class SportEventViewModel
    {
        public string SportEventId { get; set; }
        public string Title { get; set; }
        public DateTime DateOfTheEvent { get; set; }
        public string SportComplexId { get; set; }
        public string SportComplexTitle{ get; set; }
        public string SportComplexAddress { get; set; }
        public List<string> SportComplexesTitles { get; set; }
    }
}
