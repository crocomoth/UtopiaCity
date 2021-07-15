using UtopiaCity.Data;

namespace UtopiaCity.Common.Interfaces.ITimeline
{
    public interface ITimelineDbBuilder
    {
        void BuilderSet(ApplicationDbContext context);
        void ClearSet(ApplicationDbContext context);
    }
}
