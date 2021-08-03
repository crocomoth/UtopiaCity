using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UtopiaCity.Models.Life
{
    //api key ab3594366644bb53a9c73b8b92dc2a3b
    //base url http://api.mediastack.com/v1/
    //http://api.mediastack.com/v1/news   ? access_key = YOUR_ACCESS_KEY
    // optional parameters: 

    //& sources = cnn,bbc
    //& categories = business,sports
    //& countries = us,au
    //& languages = en,-de
    //& keywords = virus,-corona
    //& sort = published_desc
    //& offset = 0
    //& limit = 100
    public class Event
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        public int EventType { get; set; } //use EventType enums 0-3
    }
    public enum EventType 
    {
        general,
        business,
        entertainment,
        health,
        science,
        sports,
        technology
    }
}
