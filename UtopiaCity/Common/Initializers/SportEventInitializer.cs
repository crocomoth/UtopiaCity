using System;
using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Common.Initializers
{
    public class SportEventInitializer : ISubDbInitializer
    {

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.SportEvent.Any())
            {
                return;
            }

            var sportEvents = new SportEvent[]
            {
                new SportEvent()
                {
                    Title = "Junior Football Championship",
                    DateOfTheEvent = DateTime.Now.AddDays(20)
                },

                new SportEvent()
                {
                    Title = "Football Championship",
                    DateOfTheEvent = DateTime.Now.AddDays(25)
                },

                new SportEvent()
                {
                    Title = "Athletics Championship",
                    DateOfTheEvent = DateTime.Now.AddDays(10)
                },

                new SportEvent()
                {
                    Title = "Junior Athletics Championship",
                    DateOfTheEvent = DateTime.Now.AddDays(15)
                },

                new SportEvent()
                {
                    Title = "Swimming Championship",
                    DateOfTheEvent = DateTime.Now.AddDays(30)
                }
            };

            var sportComplexes = context.SportComplex.ToList();
            for (int i = 0; i < sportEvents.Length; i++)
            {
                sportEvents[i].SportComplex = sportComplexes.First(x => sportEvents[i].Title.Contains(x.TypeOfSport.ToString()));
            }

            context.AddRange(sportEvents);
            context.SaveChanges();
        }

        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.SportEvent.Any())
            {
                return;
            }

            context.RemoveRange(context.SportEvent.ToList());
            context.SaveChanges();
        }
    }
}