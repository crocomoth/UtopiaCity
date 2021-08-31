using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Clinic;

namespace UtopiaCity.Services.Clinic
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="ClinicVisit"/>
    /// </summary>
    public class ClinicVisitService
    {
        private readonly ApplicationDbContext _dbContext;

        public ClinicVisitService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="ClinicVisit"/> by Id.
        /// </summary>
        /// <param name="id">Id of report.</param>
        /// <returns>Report if it exists, otherwise null.</returns>
        public async Task<ClinicVisit> GetClinicVisitById(string id)
        {
            return await _dbContext.ClinicVisit.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all reports.
        /// </summary>
        /// <returns>List of all existing reports.</returns>
        public virtual async Task<List<ClinicVisit>> GetClinicVisits()
        {
            return await _dbContext.ClinicVisit.ToListAsync();
        }

        /// <summary>
        /// Method to add new reports.
        /// </summary>
        /// <param name="visit">Report to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddClinicVisit(ClinicVisit visit)
        {
            _dbContext.Add(visit);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing report.
        /// </summary>
        /// <param name="visit">Report to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateClinicVisit(ClinicVisit visit)
        {
            _dbContext.Update(visit);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing reports.
        /// </summary>
        /// <param name="visit">Report to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteClinicVisit(ClinicVisit visit)
        {
            _dbContext.Remove(visit);
            await _dbContext.SaveChangesAsync();
        }
    }
}
