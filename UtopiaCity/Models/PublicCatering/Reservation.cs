using System;

namespace UtopiaCity.Models.PublicCatering
{
    public class Reservation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int BookSeats { get; set; }
        public DateTime BookingDate { get; set; }
        public string Description { get; set; }
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}