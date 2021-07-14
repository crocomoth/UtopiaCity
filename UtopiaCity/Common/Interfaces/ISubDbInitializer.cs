using UtopiaCity.Data;

namespace UtopiaCity.Common.Interfaces
{
    public interface ISubDbInitializer
    {
        void InitializeSet(ApplicationDbContext context);

        void ClearSet(ApplicationDbContext context);
    }
}
