namespace UtopiaCity.Services.Timeline
{
    public class TimelineService
    {
        private readonly TimelineContext _dbContext;

        public TimelineService(TimelineContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
