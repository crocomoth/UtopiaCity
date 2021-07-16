using System;
using System.Linq;
using UtopiaCity.Data;

namespace UtopiaCity.Common.Initializers
{
    public class TimelineEventInitializer : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.TimelineModel.Any())
            {
                return;
            }

            context.RemoveRange(context.TimelineModel.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (!context.TimelineModel.Any())
            {
                context.TimelineModel.AddRange(
                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,

                        Schedule = "MONDAY",

                        TranscriptionOfPermission = "ALL IS RIGHT",

                        UniqueRules = "NOT SMOKING!"
                    },

                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,
                    
                        Schedule = "Friday",
                    
                        TranscriptionOfPermission = "ALL IS RIGHT",
                    
                        UniqueRules = "NOT DRINKING!"
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}
