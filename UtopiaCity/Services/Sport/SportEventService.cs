using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public virtual async Task<List<SportEvent>> GetAllSportEvents()
            => await _dbContext.SportEvents
                .Include(s => s.SportComplex)
                .ToListAsync();

        /// <summary>
        /// Gets <see cref="SportEvent"/> by Id.
        /// </summary>
        /// <param name="id">Id of sport event.</param>
        /// <returns>Sport event if it exists, otherwise null.</returns>
        public virtual async Task<SportEvent> GetSportEventById(string id)
            => await _dbContext.SportEvents
                .FirstOrDefaultAsync(x => x.SportEventId.Equals(id));

        /// <summary>
        /// Gets <see cref="SportEvent"/> by Id with it's <see cref="SportComplex"/>.
        /// </summary>
        /// <param name="id">Id of sport event.</param>
        /// <returns>Sport event with it's Sport complex if it exists, otherwise null.</returns>
        public virtual async Task<SportEvent> GetSportEventByIdWithSportComplex(string id)
            => await _dbContext.SportEvents
                .Include(s => s.SportComplex)
                .FirstOrDefaultAsync(x => x.SportEventId.Equals(id));

        /// <summary>
        /// Method for adding new sport event to database.
        /// </summary>
        /// <param name="sportEvent">Sport event for adding.</param>
        public virtual async Task AddSportEventToDb(SportEvent sportEvent)
        {
            _dbContext.Add(sportEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method for removing sport event from database.
        /// </summary>
        /// <param name="sportEvent">Sport event for removing.</param>
        public virtual async Task RemoveSportEventFromDb(SportEvent sportEvent)
        {
            _dbContext.Remove(sportEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method for updating sport event in database.
        /// </summary>
        /// <param name="sportEvent">Sport event for updating.</param>
        public virtual async Task UpdateSportEventInDb(SportEvent sportEvent)
        {
            _dbContext.Update(sportEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets list of sport events' titles.
        /// </summary>
        /// <returns>List of all existing sport events' titles.</returns>
        public virtual async Task<List<string>> GetAllSportEventsTitles()
            => await _dbContext.SportEvents
                .Select(x => x.Title)
                .ToListAsync();

        /// <summary>
        /// Gets <see cref="SportEvent.SportEventId"/> by Title.
        /// </summary>
        /// <param name="title">Title of sport event.</param>
        /// <returns>Sport event's id if it exists, otherwise null.</returns>
        public virtual async Task<string> GetSportEventIdByTitle(string title)
        {
            var sportEvent = await _dbContext.SportEvents.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return sportEvent.SportEventId;
        }
    }
}