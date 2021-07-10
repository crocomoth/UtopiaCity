using System;

namespace UtopiaCity.Models.PublicCatering
{
    public class RestaurantType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}