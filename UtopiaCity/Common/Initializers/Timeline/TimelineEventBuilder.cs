using System;
using System.Linq;
using UtopiaCity.Common.Interfaces.ITimeline;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Common.Initializers.Timeline
{
    public class TimelineEventBuilder : ITimelineDbBuilder
    {
        public void BuilderSet(ApplicationDbContext context)
        {
            if (context.EmergencyReport.Any())
            {
                return;
            }

            var defaultEvent = new TimelineModel
            {

                DayAndYear = DateTime.Now,
                Schedule = "Monday",
                TranscriptionOfPermission = "OK",
                UniqueRules = "NO SMOKING"
            };

            context.AddRange(defaultEvent);
            context.SaveChanges();
        }

        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.EmergencyReport.Any())
            {
                return;
            }

            context.RemoveRange(context.EmergencyReport.ToList());
            context.SaveChanges();
        }
    }
}
