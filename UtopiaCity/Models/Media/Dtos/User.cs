using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;

namespace UtopiaCity.Models.Media
{
    public class User /*: ICustomSoftDelete*/
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
        public DateTime RegistrationDate { get; set; }
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }

        // Realations
        public List<Advertisment> Advertisments { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
