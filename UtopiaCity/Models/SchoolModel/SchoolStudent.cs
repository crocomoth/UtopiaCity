using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.SchoolModel
{
    public class SchoolStudent
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudyYear { get; set; }
        public int AdmissionYear { get; set; }
        public DateTime recordCreated { get; set; }
        public DateTime? recordEdited { get; set; }
    }
}
