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

            var estate1 = new RealEstate
            {
                Number = "TessTea",
                Street = "TestTea",
                CompletionYear = 2015,
                EstateType = RealEstateType.Dormitory
            };

            var estate2 = new RealEstate
            {
                Number = "TessaViolet",
                Street = "TessaViolet",
                CompletionYear = 2018,
                EstateType = RealEstateType.Dormitory
            };

            var estate3 = new RealEstate
            {
                Number = "Tester",
                Street = "Tester",
                CompletionYear = 2020,
                EstateType = RealEstateType.Apartment
            };

            context.AddRange(estate1, estate2, estate3);
            context.SaveChanges();
        }
    }
}

