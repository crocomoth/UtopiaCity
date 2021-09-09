using System;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Models.Sport.Enums;

namespace UtopiaCity.ViewModels.Sport
{
    public class RequestToAdministrationViewModel
    {
        public string Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime DateOfRequest { get; set; }
        
        public bool IsApproved { get; set; }
        
        public bool IsReviewed { get; set; }
        
        public string SportComplexId { get; set; }
        
        [Required]
        public string SportComplexTitle { get; set; }
        
        public TypesOfSport TypeOfSport { get; set; }
        
        public bool Available { get; set; }
    }
}
