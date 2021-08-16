using System;
using System.Collections.Generic;
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
            if (context.SportEvents.Any())
            {
                return;
            }

            var sportEvents = new List<SportEvent>()
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
            for (int i = 0; i < sportEvents.Count; i++)
            {
                var sportComplex = sportComplexes.FirstOrDefault(x => sportEvents[i].Title
                    .Contains(x.TypeOfSport.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (sportComplex == null)
                {
                    sportEvents.RemoveAt(i--);
                }
                else
                {
                    sportEvents[i].SportComplex = sportComplex;
                }
            }

            context.AddRange(sportEvents);
            context.SaveChanges();
        }

        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.SportEvents.Any())
            {
                return;
            }

            context.RemoveRange(context.SportEvents.ToList());
            context.SaveChanges();
        }
    }
}