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
<<<<<<< HEAD
        }
        public IQueryable<Event> Search(EventDto dto)
        {
            var list = SearchByDates(from: dto.From, to: dto.To);
            list = SearchByEventType(list, dto.EventType);
            list = SearchByWord(list, dto.SearchWord);
            return list;
        }
        private IQueryable<Event> SearchByDates(DateTime? from, DateTime? to)
        {
            if (from != null && to != null)
            {
                return _dbContext.Events.Where(x => x.Date >= from && x.Date <= to);
            }
            else if (from != null)
            {
                return _dbContext.Events.Where(x => x.Date >= from);
            }
            else if (to != null)
            {
                return _dbContext.Events.Where(x => x.Date <= to);
            }
            else
            {
                return _dbContext.Events;
            }
        }
        private IQueryable<Event> SearchByEventType(IQueryable<Event> events, int? type)
        {
            if (type != null)
            {
                return events.Where(x => x.EventType.Equals(type));
            }
            else
            {
                return events;
            }
        }

        private IQueryable<Event> SearchByWord(IQueryable<Event> events, string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return events.Where(x => x.Title.Contains(word) || x.Description.Contains(word));
            }
            else
            {
                return events;
            }
        }
=======
        }        
>>>>>>> parent of 7818a12 (search panel is added to index)
    }
}
