using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.Energy
{
    public class EnergyCalculations
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Rate { get; set; }

        [Required]
        public double TotalCost { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
