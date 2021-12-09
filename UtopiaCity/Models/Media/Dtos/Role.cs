using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;

namespace UtopiaCity.Models.Media
{
    public class Role /*: ICustomSoftDelete*/
    {
        //public DateTime? DeletedAt { get; set; } = null;
        //public bool IsActive { get; set; } = true;

        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<User> Users { get; set; }

        public Role()
        {
            Employees = new List<Employee>();
            Users = new List<User>();
        }
    }
}
