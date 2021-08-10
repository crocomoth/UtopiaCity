using System;

namespace UtopiaCity.Models.Emergency
{
    public partial class EmergencyCertificate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string SerialNumber { get; set; }
        public string Salt { get; set; }
    }
}
