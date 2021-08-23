using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportComplexBaseViewModel
    {
        public string SportComplexId { get; set; }
        [Required]
        public string SportComplexTitle { get; set; }
        [Required]
        public string Address { get; set; }
        public bool Available { get; set; }
    }
}