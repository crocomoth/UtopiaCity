using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtopiaCity.Models.CitizenAccount
{
    /// <summary>
    /// Represent user messages.
    /// </summary>
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; } = DateTime.Now;

        [Required]
        public string Author { get; set; }
        public virtual AppUser Sender { get; set; }

        [Required]
        public string TalkId { get; set; }
        public Talk Talk { get; set; }

    }
}
