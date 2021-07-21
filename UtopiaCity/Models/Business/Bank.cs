﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Business
{
    public class Bank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [DisplayName("Название банка")]
        public string Name { get; set; }

        [Required]
        [DisplayName("БИК банка")]
        [StringLength(8, MinimumLength = 8)]
        public string BIK { get; set; }
    }
}
