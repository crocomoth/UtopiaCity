using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.TV
{
    public class CelebrityList
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sname { get; set; }
        public DateTime DateBirth { get; set; }
        public string Career { get; set; }
        public string Awards { get; set; }
    }
}
