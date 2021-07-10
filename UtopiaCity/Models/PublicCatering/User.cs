using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UtopiaCity.Models.PublicCatering
{
    public class User : IdentityUser
    {
        public virtual List<Reservation> Reservations { get; set; } 
    }
}