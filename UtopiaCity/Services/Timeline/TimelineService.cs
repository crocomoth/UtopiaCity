using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Services.Timeline
{
    public class TimelineService
    {
        private readonly ApplicationDbContext _dbContext;

        public TimelineService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// CREATE METHOD 
        /// </summary>
        /// <param name="newEvent">MODEL OF EVENT</param>
        /// <returns>NEW EVENT</returns>
        public async Task CreateNewEvent(TimelineModel newEvent)
        {
            _dbContext.Add(newEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// EDIT EVENT
        /// </summary>
        /// <param name="chosenEvent">EVENT</param>
        /// <returns>EDITED EVENT</returns>
        public async Task EditEvent(TimelineModel chosenEvent)
        {
            _dbContext.Update(chosenEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// DELETE(REMOVE) EVENT
        /// </summary>
        /// <param name="chosenEvent">EVENT</param>
        /// <returns>NEW LIST WITH OUR 1 EVENT</returns>
        public async Task DeleteEvent(TimelineModel chosenEvent)
        {
            _dbContext.Remove(chosenEvent);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// SHOW EVENT BY ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>EVENT OR NOTHING</returns>
        public async Task<TimelineModel> GetEventById(string id)
        {
            return await _dbContext.TimelineModel.FirstOrDefaultAsync(e => e.ID.Equals(id));
        }

        /// <summary>
        /// SHOW LIST OF EVENT
        /// </summary>
        /// <returns>LIST</returns>
        public async Task<List<TimelineModel>> GetList()
        {
            return await _dbContext.TimelineModel.ToListAsync();
        }

    }
}

