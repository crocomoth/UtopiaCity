using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Models.PublicCatering
{
    public sealed class Reservation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required (ErrorMessage = "The BookSeats field is required!")]
        public int BookSeats { get; set; }
        [Required (ErrorMessage = "The BookingDate field is required!")]
        public DateTime BookingDate { get; set; }
        public string Description { get; set; }
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}