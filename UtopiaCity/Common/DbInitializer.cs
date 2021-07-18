using System.Collections.Generic;
using UtopiaCity.Common.Initializers;
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
            // simple sets
            subDbInitializers.Add(new EmergencyReportInitializer());

            subDbInitializers.Add(new FlightInitializer());

            subDbInitializers.Add(new SportComplexInitializer());


            // complex sets
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
