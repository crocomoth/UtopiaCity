using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicCatering;

namespace UtopiaCity.Common.Initializers
{
    public class PublicCateringInitializer : ISubDbInitializer
    {
        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.RestaurantTypes.Any())
            {
                if (context.Restaurants.Any())
                {
                    return;
                }
            }

            if (!context.RestaurantTypes.Any())
            {
                object[] restaurantType =
                {
                    new RestaurantType
                    {
                        Name = "Caffe"
                    },
                    new RestaurantType
                    {
                        Name = "Bar"
                    },
                    new RestaurantType
                    {
                        Name = "Restaurant"
                    },
                    new RestaurantType
                    {
                        Name = "Eatery"
                    },
                    new RestaurantType
                    {
                        Name = "Teahouse"
                    }
                };
                context.AddRange(restaurantType);
                context.SaveChanges();
            }

            if (!context.Restaurants.Any())
            {
                object[] restaurant =
                {
                    new Restaurant
                    {
                        Name = "The Ivy Market Grill",
                        Address = "1 Henrietta Street, Covent Garden London, WC2E 8PS",
                        Seats = 40
                    },
                    new Restaurant
                    {
                        Name = "Dishoom Covent Garden",
                        Address = "12 Upper St Martin's Ln, London WC2H 9FB",
                        Seats = 20
                    },
                    new Restaurant
                    {
                        Name = "Hawksmoor Seven Dials",
                        Address = "11 Langley St, London WC2H 9JG",
                        Seats = 24
                    },
                    new Restaurant
                    {
                        Name = "The Real Greek - Covent Garden",
                        Address = "60-62 Long Acre, London WC2E 9JE",
                        Seats = 10
                    },
                    new Restaurant
                    {
                        Name = "La Ballerina Covent Garden",
                        Address = "7-8 Bow St, London WC2E 7AH",
                        Seats = 100
                    }
                };
                context.AddRange(restaurant);
                context.SaveChanges();
            }
        }

        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.RestaurantTypes.Any())
            {
                if (!context.Restaurants.Any())
                {
                    return;
                }
            }
            
            if (context.RestaurantTypes.Any())
            {
                context.RemoveRange(context.RestaurantTypes.ToList());
                context.SaveChanges();
            }
            
            if (context.Restaurants.Any())
            {
                context.RemoveRange(context.Restaurants.ToList());
                context.SaveChanges();
            }
        }
    }
}