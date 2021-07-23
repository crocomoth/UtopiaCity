using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;

namespace UtopiaCity.Common.Initializers
{
    public class RealEstateInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.RealEstate.Any())
            {
                return;
            }

            context.RemoveRange(context.RealEstate.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.RealEstate.Any())
            {
                return;
            }

            var realEstate1 = new RealEstate
            {
                Type = EstateType.Apartment,
                Address = "1 Street, 1"
            };

            var realEstate2 = new RealEstate
            {
                Type = EstateType.Apartment,
                Address = "1 Street, 2"
            };

            var realEstate3 = new RealEstate
            {
                Type = EstateType.Apartment,
                Address = "1 Street, 3"
            };

            var realEstate4 = new RealEstate
            {
                Type = EstateType.Apartment,
                Address = "1 Street, 4"
            };

            var realEstate5 = new RealEstate
            {
                Type = EstateType.Apartment,
                Address = "1 Street, 5"
            };

            context.AddRange(realEstate1, realEstate2, realEstate3, realEstate4, realEstate5);
            context.SaveChanges();
        }
    }
}
