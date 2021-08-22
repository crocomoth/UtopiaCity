using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Services.Sport
{
    public class SportTicketService
    {
        private readonly ApplicationDbContext _dbContext;

        public SportTicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual List<SportTicket> GetAllSportTickets() => _dbContext.SportTickets
            .Include(s => s.SportComplex)
            .Include(e => e.SportEvent)
            .Include(u => u.AppUser)
            .ToList();

        public virtual SportTicket GetSportTicketById(string id) => _dbContext.SportTickets
            .Include(s => s.SportComplex)
            .Include(e => e.SportEvent)
            .Include(u => u.AppUser)
            .FirstOrDefault(s => s.TicketId.Equals(id));

        public virtual void AddSportTicketToDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Add(sportTicket);
            _dbContext.SaveChanges();
        }

        public virtual void UpdateSportTicketInDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Update(sportTicket);
            _dbContext.SaveChanges();
        }

        public virtual void RemoveSportTicketFromDb(SportTicket sportTicket)
        {
            _dbContext.SportTickets.Remove(sportTicket);
            _dbContext.SaveChanges();
        }
    }
}
