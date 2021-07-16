using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Services.Sport
{
    public class SportEventService
    {
        private readonly ApplicationDbContext _dbContext;

        public SportEventService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SportEvent> GetAllSportEvents() => _dbContext.SportEvent.ToList();

        public SportEvent GetSportEventById(string id) => _dbContext.SportEvent.FirstOrDefault(x => x.SportEventId.Equals(id));

        public void AddSportEventToDb(SportEvent sportEvent)
        {
            _dbContext.Add(sportEvent);
            _dbContext.SaveChanges();
        }

        public void RemoveSportEventFromDb(SportEvent sportEvent)
        {
            _dbContext.Remove(sportEvent);
            _dbContext.SaveChanges();
        }

        public void UpdateSportEventInDb(SportEvent sportEvent)
        {
            _dbContext.Update(sportEvent);
            _dbContext.SaveChanges();
        }
    }
}
