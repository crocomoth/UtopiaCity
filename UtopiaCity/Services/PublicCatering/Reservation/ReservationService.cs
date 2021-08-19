using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;

namespace UtopiaCity.Services.PublicCatering.Reservation
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.PublicCatering.Reservation> GetReservationById(string id)
        {
            return await _dbContext.Reservations.Include(r => r.Restaurant).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<Models.PublicCatering.Reservation>> GetReservations()
        {
            return await _dbContext.Reservations.Include(r => r.Restaurant).ToListAsync();
        }

        public async Task AddReservation(Models.PublicCatering.Reservation reservation)
        {
            _dbContext.Add(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReservation(Models.PublicCatering.Reservation reservation)
        {
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReservation(Models.PublicCatering.Reservation reservation)
        {
            _dbContext.Remove(reservation);
            await _dbContext.SaveChangesAsync();
        }
    }
}