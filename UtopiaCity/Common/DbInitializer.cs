using System.Collections.Generic;
using UtopiaCity.Common.CitizenAccount;
using UtopiaCity.Common.Initializers;
using UtopiaCity.Common.Initializers.AirportTransportSystem;
using UtopiaCity.Common.Initializers.CitizenAccount;
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
            subDbInitializers.Add(new TimelineEventInitializer());
            subDbInitializers.Add(new ResidentAccountInitializer());         
            subDbInitializers.Add(new FlightInitializer());          
            subDbInitializers.Add(new ForPassengerInitializer());          
            subDbInitializers.Add(new SportComplexInitializer());
            subDbInitializers.Add(new LifeInitializer());
            subDbInitializers.Add(new RealEstateInitializer());
            subDbInitializers.Add(new BankInitializer());
            subDbInitializers.Add(new CompanyStatusInitializer());
            subDbInitializers.Add(new CompanyInitializer());
            subDbInitializers.Add(new ProfessionInitializer());
            subDbInitializers.Add(new EmployeeInitializer());
            subDbInitializers.Add(new VacancyInitializer());
            subDbInitializers.Add(new ResumeInitializer());
            subDbInitializers.Add(new ClinicVisitInitializer());
            subDbInitializers.Add(new SportEventInitializer());
            subDbInitializers.Add(new CitizenUsersInitializer());
            subDbInitializers.Add(new CitizenTaskInitializer());
            subDbInitializers.Add(new FriendInitizalier());
            subDbInitializers.Add(new TalkInitializer());
            subDbInitializers.Add(new MessageInitializer());
            subDbInitializers.Add(new FireSafetyDepartmentInitializer());
            subDbInitializers.Add(new PositionInitializer());
            subDbInitializers.Add(new TransportManagementInitializer());
            subDbInitializers.Add(new EmployeeManagementInitializer());
            subDbInitializers.Add(new DepatureToThePlaceInitializer());
            subDbInitializers.Add(new FireMessageInitializer());
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
