using Microsoft.EntityFrameworkCore;
using UtopiaCity.Common;
using UtopiaCity.Data;
using UtopiaCity.Utils;

namespace UtopiaCityTest.Services
{
    public abstract class BaseServiceTest
    {
        protected static object LockObject = new object();
        protected static bool Initialized;
        protected DbContextOptions<ApplicationDbContext> options;

        protected virtual void Setup()
        {
            if (!Initialized)
            {
                lock (LockObject)
                {
                    if (!Initialized)
                    {
                        DbInitializer.RegisterSubInitializers();
                        Initialized = true;
                    }
                }
            }

            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: RandomUtil.GenerateRandomString(15) + "UtopiaCityTest").Options;

            using (var context = new ApplicationDbContext(options))
            {
                DbInitializer.InitializeDb(context);
            }
        }

        protected virtual void TearDown()
        {
            using (var context = new ApplicationDbContext(options))
            {
                DbInitializer.ClearDb(context);
            }
        }
    }
}
