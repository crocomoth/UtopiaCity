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
    /// Class to handle basic CRUD operations for <see cref="ClinicReport"/>
    /// </summary>
    public class ClinicReportService
    {
        private readonly ApplicationDbContext _dbContext;

        public ClinicReportService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="ClinicReport"/> by Id.
        /// </summary>
        /// <param name="id">Id of report.</param>
        /// <returns>Report if it exists, otherwise null.</returns>
        public async Task<ClinicReport> GetClinicReportById(string id)
        {
            return await _dbContext.ClinicReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all reports.
        /// </summary>
        /// <returns>List of all existing reports.</returns>
        public virtual async Task<List<ClinicReport>> GetClinicReports()
        {
            return await _dbContext.ClinicReport.ToListAsync();
        }

        /// <summary>
        /// Method to add new reports.
        /// </summary>
        /// <param name="report">Report to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddClinicReport(ClinicReport report)
        {
            _dbContext.Add(report);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing report.
        /// </summary>
        /// <param name="report">Report to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateClinicReport(ClinicReport report)
        {
            _dbContext.Update(report);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing reports.
        /// </summary>
        /// <param name="report">Report to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteClinicReport(ClinicReport report)
        {
            _dbContext.Remove(report);
            await _dbContext.SaveChangesAsync();
        }
    }
}
