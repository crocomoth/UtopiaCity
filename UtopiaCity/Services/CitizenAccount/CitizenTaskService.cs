using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="CitizensTask"/>
    /// </summary>
    public class CitizenTaskService
    {
        private readonly ApplicationDbContext _dbContext;

        public CitizenTaskService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="CitizensTask"/> by Id.
        /// </summary>
        /// <param name="id">Id of citizen task.</param>
        /// <returns>Citizen task if it exists, otherwise null.</returns>
        public async Task<CitizensTask> GetTaskById(string id)
        {
            return await _dbContext.CitizensTasks.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all citizen task order by reminder date.
        /// </summary>
        /// <returns>List of all existing citizen tasks.</returns>
        public async Task<List<CitizensTask>> GetTasksByReminderDate(string userId)
        {
            return await _dbContext.CitizensTasks.Where(x => x.UserId == userId).OrderBy(x => x.ReminderDate).ToListAsync();
        }

        /// <summary>
        /// Method to add new citizen task.
        /// </summary>
        /// <param name="citizensTask">Citizen task to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddCitizenTask(CitizensTask citizensTask)
        {
            _dbContext.Add(citizensTask);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update citizen task.
        /// </summary>
        /// <param name="citizensTask">Citizen task to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateCitizenTask(CitizensTask citizensTask)
        {
            _dbContext.Update(citizensTask);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing citizen task.
        /// </summary>
        /// <param name="citizensTask">Citizen task to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteCitizenTask(CitizensTask citizensTask)
        {
            _dbContext.Remove(citizensTask);
            await _dbContext.SaveChangesAsync();
        }
    }
}
