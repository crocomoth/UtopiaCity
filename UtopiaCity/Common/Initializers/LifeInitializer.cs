using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.Life;

namespace UtopiaCity.Common.Initializers
{
    public class LifeInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Events.Any())
            {
                return;
            }

            context.RemoveRange(context.Events.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            var events = new List<Event> {
                new Event { Title="Sunny day", Date=DateTime.Now.AddDays(-1),Description="Extremely hot day in the city.",EventType=(int)EventType.Weather },
                new Event { Title="Baby boom", Date=DateTime.Now.AddDays(-2),Description="101 babies were born at the hospital in one hour.",EventType=(int)EventType.News},
                new Event { Title="New world record", Date=DateTime.Now,Description="The city athlete has made the longest jump in the world, 15.73 meters.",EventType=(int)EventType.Sport},
                new Event { Title="This is a fake city", Date=DateTime.Now.AddDays(-3),Description="All around is fake. Developers created this world.",EventType=(int)EventType.Unknown},
            };
            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}
