using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;

namespace UtopiaCity.Models.Media
{
    public class DataCapture /*: ICustomSoftDelete*/
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Header { get; set; }

        [Required]
        [MinLength(100)]
        public string Content { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PublicationDate { get; set; } = null;

        [ScaffoldColumn(false)]
        public bool? EditorApprove { get; set; } = null; //null waiting | false declined | true accessed

        [ScaffoldColumn(false)]
        public bool? ApproversApprove { get; set; } = null; //null waiting | false declined | true accessed

        // Relations
        public Employee Employee { get; set; }

        public string EmployeeId { get; set; }

    }
}
