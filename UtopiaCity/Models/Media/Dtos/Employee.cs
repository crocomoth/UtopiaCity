using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;

namespace UtopiaCity.Models.Media
{
    public class Employee /*: ICustomSoftDelete*/
    {
        //public DateTime? DeletedAt { get; set; } = null;
        //public bool IsActive { get; set; } = true;

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        public DateTime EmployementDate { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        // Relations
        public List<Advertisment> Advertisments { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
