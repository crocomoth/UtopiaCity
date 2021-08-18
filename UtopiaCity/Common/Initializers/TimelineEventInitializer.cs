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

            if (!context.PermitedModel.Any())
            {
                return;
            }

            context.RemoveRange(context.TimelineModel.ToList());
            
            context.RemoveRange(context.PermitedModel.ToList());

            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            CultureInfo myCounty = new CultureInfo("ru-Ru");

            DateTime dayAndYear = DateTime.Now;

            string dd = dayAndYear.ToString("dd:yy", myCounty);

            Console.WriteLine(dayAndYear);

            //GetPendingMigrations попробывать
            if (!context.TimelineModel.Any())
            {

                context.TimelineModel.AddRange(
                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,

                        Schedule = dd,

                        TranscriptionOfPermission = "ALL IS RIGHT",

                        UniqueRules = "NOT SMOKING!"
                    },

                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,
                    
                        Schedule = dd,
                    
                        TranscriptionOfPermission = "ALL IS RIGHT",
                    
                        UniqueRules = "NOT DRINKING!"
                    },

                    new Models.TimelineModel.TimelineModel
                    {
                        DayAndYear = DateTime.Now,
                    
                        Schedule = dd,
                    
                        TranscriptionOfPermission = "ALL IS RIGHT",
                    
                        UniqueRules = "NOT SMOKING!"
                    }
                    );
            }

            //Permited Conditons
            if(!context.PermitedModel.Any())
            {
                context.PermitedModel.AddRange(
                    new Models.TimelineModel.PermitedModel
                    {
                        PermissionDate = DateTime.Now,
                        Season = "Winter",
                        SpeedOfWind = "10",
                        GovernmentStatus = false,
                        Rainfall = "rain",
                        TimeOfDay = "night",
                        PermissionStatus = "takeof allowed"
                    },

                    new Models.TimelineModel.PermitedModel
                    {
                        PermissionDate=DateTime.Now.AddDays(2),
                        Season = "Winter",
                        SpeedOfWind = "9",
                        GovernmentStatus = false,
                        Rainfall = "rain",
                        TimeOfDay = "night",
                        PermissionStatus = "takeof prohibited"
                    },

                    new Models.TimelineModel.PermitedModel
                    {
                        PermissionDate=DateTime.Now.AddDays(1),
                        Season = "Summer",
                        SpeedOfWind = "7",
                        GovernmentStatus = true,
                        Rainfall = "none",
                        TimeOfDay = "day",
                        PermissionStatus = "takeof is postponed"
                    }

                    );
            }


            context.SaveChanges();
        }
    }
}
