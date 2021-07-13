using System;
using System.Collections;

namespace UtopiaCity.Models.PublicCatering
{
    public class RestaurantType : IEnumerable
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}