using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;

namespace UtopiaCity.Models.Media
{
    public class Advertisment /*: ICustomSoftDelete*/
    {
        //public DateTime? DeletedAt { get; set; } = null;
        //public bool IsActive { get; set; } = true;

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }

        // Relations
        public string UserId { get; set; }
        public User User { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
