using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent citizen friend.
    /// </summary>
    public class Friend
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string FirstUserId { get; set; }
        public AppUser FirstUser { get; set; }
        public string SecondUserId { get; set; }
        public AppUser SecondUser { get; set; }
        public FriendsStatus FriendsStatus { get; set; }
    }
}
