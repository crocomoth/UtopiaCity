using System;
using System.ComponentModel.DataAnnotations;
using UtopiaCity.Models.PublicCatering.Enums;

namespace UtopiaCity.Models.PublicCatering
{
    public class Restaurant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required (ErrorMessage = "The Name field is required!")]
        public string Name { get; set; }
        [Required (ErrorMessage = "The Adress field is required!")]
        public string Address { get; set; }
        public Status Status { get; set; } = Status.Open;
        [Range(1, 500, ErrorMessage = "The number of seats is not correct!")]
        public int Seats { get; set; }
        public string RestaurantTypeId { get; set; }
        public RestaurantType RestaurantType { get; set; }
    }
}