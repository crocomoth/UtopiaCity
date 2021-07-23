using System;
using System.Globalization;
using System.Linq;
using UtopiaCity.Common.Interfaces;
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
            CultureInfo myCounty = new CultureInfo("ru-Ru");

            DateTime dayAndYear = DateTime.Now;

            string day = dayAndYear.Day.ToString(myCounty);

            string year= dayAndYear.Year.ToString(myCounty);

            string dayAndYearProp = string.Concat(day, "/", year);

            Console.WriteLine(dayAndYear);

            //GetPendingMigrations попробывать
            if (!context.TimelineModel.Any())
            {

                context.TimelineModel.AddRange(
                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,

                        Schedule = dayAndYearProp,

                        TranscriptionOfPermission = "ALL IS RIGHT",

                        UniqueRules = "NOT SMOKING!"
                    },

                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,
                    
                        Schedule = "Friday",
                    
                        TranscriptionOfPermission = "ALL IS RIGHT",
                    
                        UniqueRules = "NOT DRINKING!"
                    },

                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,
                    
                        Schedule = dayAndYearProp,
                    
                        TranscriptionOfPermission = "ALL IS RIGHT",
                    
                        UniqueRules = "NOT SMOKING!"
                    }
                    );
            }

            context.SaveChanges();
        }
    }
}
