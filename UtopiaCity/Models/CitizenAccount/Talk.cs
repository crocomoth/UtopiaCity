using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent talk beetwen users.
    /// </summary>
    public class Talk
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string  Id { get; set; }

        public string UserOneId { get; set; }
        public AppUser UserOne { get; set; }

        public string UserTwoId { get; set; }
        public AppUser UserTwo { get; set; }
    }
}
