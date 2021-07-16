using UtopiaCity.Data;

namespace UtopiaCity.Common
{
    public interface ISubDbInitializer
    {
        void InitializeSet(ApplicationDbContext context);

        void ClearSet(ApplicationDbContext context);
    }
}