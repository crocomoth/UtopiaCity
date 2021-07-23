using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Life;

namespace UtopiaCity.Services.Life
{
    public class LifeService
    {
        private ApplicationDbContext _dbContext;
        public LifeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Event> GetAll()
        {
            return _dbContext.Events.ToList();
        }
        public Event GetById(string id)
        {
            if (!string.IsNullOrEmpty(id) && _dbContext.Events.Any(x => x.Id.Equals(id)))
            {
                return _dbContext.Events.FirstOrDefault(x => x.Id.Equals(id));
            }
            else
            {
                return null;
            }
        }
        public List<Event> GetByEventType(EventType type)
        {
            if (_dbContext.Events.Any(x => x.EventType == (int)type))
            {
                return _dbContext.Events.Where(x => x.EventType == (int)type).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<Event> GetByDates(DateTime from, DateTime to)
        {
            if (_dbContext.Events.Any(x => x.Date >= from && x.Date <= to))
            {
                return _dbContext.Events.Where(x => x.Date >= from && x.Date <= to).ToList();
            }
            else
            {
                return null;
            }
        }
        public void Add(Event ev)
        {
            _dbContext.Events.Add(ev);
            _dbContext.SaveChanges();
        }
        public void Update(Event ev)
        {
            _dbContext.Events.Update(ev);
            _dbContext.SaveChanges();
        }
        public void Remove(Event ev)
        {
            _dbContext.Events.Remove(ev);
            _dbContext.SaveChanges();
        }
        public bool Exist(string id)
        {
            return _dbContext.Events.Any(x => x.Id.Equals(id));
        }        
    }
}
