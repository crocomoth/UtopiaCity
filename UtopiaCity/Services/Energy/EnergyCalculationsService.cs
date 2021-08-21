using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Energy;

namespace UtopiaCity.Services.Energy
{
    public class EnergyCalculationsService
    {
        private readonly ApplicationDbContext _dbContext;

        public EnergyCalculationsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="EnergyCalculations"/> by Id.
        /// </summary>
        /// <param name="id">Id of calculations.</param>
        /// <returns>Energy calculation if it exists, otherwise null.</returns>
        public async Task<EnergyCalculations> GetEnergyCalculationById(string id)
        {
            return await _dbContext.EnergyCalculations.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all calculations.
        /// </summary>
        /// <returns>List of all energy calculations.</returns>
        public async Task<List<EnergyCalculations>> GetEnergyCalculations()
        {
            return await _dbContext.EnergyCalculations.ToListAsync();
        }

        /// <summary>
        /// Method to add new calculations.
        /// </summary>
        /// <param name="calculations"> to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddEnergyCalculations(EnergyCalculations calculations)
        {
            _dbContext.Add(calculations);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing calculation.
        /// </summary>
        /// <param name="calculations"> to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateEnergyCalculations(EnergyCalculations calculations)
        {
            _dbContext.Update(calculations);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing calculations.
        /// </summary>
        /// <param name="calculations"> to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteEnergyCalculations(EnergyCalculations calculations)
        {
            _dbContext.Remove(calculations);
            await _dbContext.SaveChangesAsync();
        }
    }
}
