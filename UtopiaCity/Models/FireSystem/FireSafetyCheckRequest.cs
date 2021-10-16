using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.FireSystem
{
    public class FireSafetyCheckRequest
    {
        [ScaffoldColumn(false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required, MaxLength(25)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string ObjectName { get; set; }
    }
}
