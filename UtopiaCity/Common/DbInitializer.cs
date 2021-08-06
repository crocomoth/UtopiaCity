using System.Collections.Generic;
using System.Runtime.InteropServices;
using UtopiaCity.Common.Initializers;
using UtopiaCity.Common.Initializers.AirportTransportSystem;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;

namespace UtopiaCity.Common
{
    /// <summary>
    /// Class to clear and initialize database
    /// </summary>
    public static class DbInitializer
    {
        private static readonly List<ISubDbInitializer> subDbInitializers = new List<ISubDbInitializer>();

        public static void RegisterSubInitializers()
        {
            subDbInitializers.Add(new EmergencyReportInitializer());
            subDbInitializers.Add(new ResidentAccountInitializer());
            subDbInitializers.Add(new SportComplexInitializer());
            subDbInitializers.Add(new LifeInitializer());
            subDbInitializers.Add(new TimelineEventInitializer());

            // complex sets
            subDbInitializers.Add(new FlightInitializer());
            subDbInitializers.Add(new ForPassengerInitializer());
        }

        public static void InitializeDb(ApplicationDbContext context)
        {
            foreach (var initializer in subDbInitializers)
            {
                initializer.InitializeSet(context);
            }
        }

        public static void ClearDb(ApplicationDbContext context)
        {
            foreach (var initializer in subDbInitializers)
            {
                initializer.ClearSet(context);
            }
        }
    }
}