using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.Initializers.CitizenAccount
{
    public class TalkInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Talks.Any())
            {
                return;
            }

            context.RemoveRange(context.Talks.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Talks.Any())
            {
                return;
            }

            var talk1 = new Talk
            { 
                Id="1",
                UserOneId= "1",
                UserTwoId= "4"
            };
            


            context.AddRange(talk1);
            context.SaveChanges();
        }
    }
}
