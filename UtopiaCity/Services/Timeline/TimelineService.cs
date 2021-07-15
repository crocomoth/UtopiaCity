using UtopiaCity.Data;

namespace UtopiaCity.Services.Timeline
{
    public class TimelineService
    {
        private readonly ApplicationDbContext _dbContext;

        public TimelineService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
