using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Models.Sport
{
    public class SportTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TicketId { get; set; }

        [Required]
        [ForeignKey("SportComplex")]
        public string SportComplexId { get; set; }

        [Required]
        [ForeignKey("SportEvent")]
        public string SportEventId { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        public SportComplex SportComplex { get; set; }
        public SportEvent SportEvent { get; set; }
        public AppUser AppUser { get; set; }
    }
}