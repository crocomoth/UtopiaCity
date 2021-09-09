using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.ViewModels.Sport
{
    public class SportComplexBaseViewModel
    {
        public string SportComplexId { get; set; }

        [Required]
        [RegularExpression(@"[^' ']([A-Za-z0-9]{1,}([' ']{0,1})){1,}[^' ']", ErrorMessage = "Enter correct title")]
        public string SportComplexTitle { get; set; }

        [Required]
        [RegularExpression(@"[^' ']([A-Za-z0-9]{1,}([' ']{0,1})){1,}[^' ']", ErrorMessage = "Enter correct address")]
        public string Address { get; set; }

        [Required]
        public bool Available { get; set; }
    }
}