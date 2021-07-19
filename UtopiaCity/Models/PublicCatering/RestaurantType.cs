using System;
using System.ComponentModel.DataAnnotations;

namespace UtopiaCity.Models.PublicCatering
{
    public class RestaurantType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required (ErrorMessage = "The Name field is required!")]
        public string Name { get; set; }
    }
}