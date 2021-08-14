using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using Microsoft.EntityFrameworkCore;

namespace UtopiaCity.Services.Sport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="SportEvent"/>
    /// </summary>
    public class SportEventService
    {
        private readonly ApplicationDbContext _dbContext;

        public SportEventService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of all sport events with their sport complexes.
        /// </summary>
        /// <returns>List of all existing sport events with their sport complexes.</returns>
        public virtual List<SportEvent> GetAllSportEvents() => _dbContext.SportEvents.Include(s => s.SportComplex).ToList();

        /// <summary>
        /// Gets <see cref="SportEvent"/> by Id.
        /// </summary>
        /// <param name="id">Id of sport event.</param>
        /// <returns>Sport event if it exists, otherwise null.</returns>
        public virtual SportEvent GetSportEventById(string id) => _dbContext.SportEvents.FirstOrDefault(x => x.SportEventId.Equals(id));

        /// <summary>
        /// Gets <see cref="SportEvent"/> by Id with it's <see cref="SportComplex"/>.
        /// </summary>
        /// <param name="id">Id of sport event.</param>
        /// <returns>Sport event with it's Sport complex if it exists, otherwise null.</returns>
        public virtual SportEvent GetSportEventByIdWithSportComplex(string id) => _dbContext.SportEvents.Include(s => s.SportComplex).FirstOrDefault(x => x.SportEventId.Equals(id));

        /// <summary>
        /// Method for adding new sport event to database.
        /// </summary>
        /// <param name="sportEvent">Sport event for adding.</param>
        public virtual void AddSportEventToDb(SportEvent sportEvent)
        {
            _dbContext.Add(sportEvent);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for removing sport event from database.
        /// </summary>
        /// <param name="sportEvent">Sport event for adding.</param>
        public virtual void RemoveSportEventFromDb(SportEvent sportEvent)
        {
            _dbContext.Remove(sportEvent);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for updating sport event in database.
        /// </summary>
        /// <param name="sportEvent">Sport event for adding.</param>
        public virtual void UpdateSportEventInDb(SportEvent sportEvent)
        {
            _dbContext.Update(sportEvent);
            _dbContext.SaveChanges();
        }
    }
}