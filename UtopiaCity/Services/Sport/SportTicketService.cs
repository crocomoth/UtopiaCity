using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Services.Sport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="SportTicket"/>
    /// </summary>
    public class SportTicketService
    {
        private readonly ApplicationDbContext _dbContext;

        public SportTicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of all sport tickets with their relational information.
        /// </summary>
        /// <returns>List of all existing sport tickets with their relational information.</returns>
        public virtual List<SportTicket> GetAllSportTickets(string id) => _dbContext.SportTickets
            .Where(i => i.AppUserId.Equals(id))
            .Include(s => s.SportComplex)
            .Include(e => e.SportEvent)
            .Include(u => u.AppUser)
            .ToList();

        /// <summary>
        /// Gets <see cref="SportTicket"/> by Id.
        /// </summary>
        /// <param name="id">Id of sport ticket.</param>
        /// <returns>Sport ticket if it exists, otherwise null.</returns>
        public virtual SportTicket GetSportTicketById(string id) => _dbContext.SportTickets
            .Include(s => s.SportComplex)
            .Include(e => e.SportEvent)
            .Include(u => u.AppUser)
            .FirstOrDefault(s => s.TicketId.Equals(id));

        /// <summary>
        /// Method for adding new sport ticket to database.
        /// </summary>
        /// <param name="sportTicket">Sport ticket for adding.</param>
        public virtual void AddSportTicketToDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Add(sportTicket);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for updating sport ticket in database.
        /// </summary>
        /// <param name="sportTicket">Sport ticket for adding.</param>
        public virtual void UpdateSportTicketInDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Update(sportTicket);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for removing sport ticket from database.
        /// </summary>
        /// <param name="sportTicket">Sport ticket for adding.</param>
        public virtual void RemoveSportTicketFromDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Remove(sportTicket);
            _dbContext.SaveChanges();
        }
    }
}
