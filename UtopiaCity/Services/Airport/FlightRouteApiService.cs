using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    public class FlightRouteApiService : IRouteApi
    {
        private static readonly HttpClient client;
        static FlightRouteApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://dev.virtualearth.net")
            };
        }
        public async Task<List<Resource>> GetRouteObject(string locationPoint, string destinationPoint)
        {
            var url = string.Format("/REST/v1/Routes?o=json&wp.1={0}&wp.2={1}&routeAttributes=routeSummariesOnly&key=AjQ6wnSYZLHRNMktwK83yKJ74D6d8OxxeXnmxfHP06qvgO178FUYvHdc4V-YBApY", locationPoint, destinationPoint);
            _ = new List<Resource>();
            var response = await client.GetAsync(url);
            List<Resource> result;
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Resource>(stringResponse)
                                    .ResourceSets.ElementAtOrDefault(0).Resources;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
