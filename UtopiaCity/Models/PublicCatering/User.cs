using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UtopiaCity.Models.PublicCatering
{
    public sealed class User : IdentityUser
    {
        public List<Reservation> Reservations { get; set; } 
    }
}