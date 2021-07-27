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
        public List<Event> Search(EventDto dto)
        {
            var list = SearchByDates(from: dto.From, to: dto.To);
            list = SearchByEventType(list, dto.EventType);
            list = SearchByWord(list, dto.SearchWord);
            return list;
        }
        private List<Event> SearchByDates(DateTime? from, DateTime? to)
        {
            if (from != null && to != null)
            {
                return _dbContext.Events.Where(x => x.Date >= from && x.Date <= to).ToList();
            }
            else if (from != null)
            {
                return _dbContext.Events.Where(x => x.Date >= from).ToList();
            }
            else if (to != null)
            {
                return _dbContext.Events.Where(x => x.Date <= to).ToList();
            }
            else
            {
                return _dbContext.Events.ToList();
            }
        }
        private List<Event> SearchByEventType(List<Event> events, int? type)
        {
            if (type != null)
            {
                return events.Where(x => x.EventType.Equals(type)).ToList();
            }
            else
            {
                return events;
            }
        }

        private List<Event> SearchByWord(List<Event> events, string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return events.Where(x => x.Title.Contains(word) || x.Description.Contains(word)).ToList();
            }
            else
            {
                return events;
            }
        }
    }
}
