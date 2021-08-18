using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;

namespace UtopiaCity.Services.Emergency
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="EmergencyReport"/>
    /// </summary>
    public class EmergencyReportService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public EmergencyReportService(ApplicationDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        /// <summary>
        /// Gets <see cref="EmergencyReport"/> by Id.
        /// </summary>
        /// <param name="id">Id of report.</param>
        /// <returns>Report if it exists, otherwise null.</returns>
        public async Task<EmergencyReport> GetEmergencyReportById(string id)
        {
            if (_cache.TryGetValue(id, out EmergencyReport report))
            {
                return report;
            }

            var notCachedReport = await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _cache.Set(id, notCachedReport, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
            //await _cache.GetOrCreateAsync(id, async (ICacheEntry e) => await _dbContext.EmergencyReport.FirstOrDefaultAsync(x => x.Id.Equals(id)));
            return notCachedReport;
        }

        /// <summary>
        /// Gets list of all reports.
        /// </summary>
        /// <returns>List of all existing reports.</returns>
        public virtual async Task<List<EmergencyReport>> GetEmergencyReports()
        {
            return await _dbContext.EmergencyReport.ToListAsync();
        }

        /// <summary>
        /// Method to add new reports.
        /// </summary>
        /// <param name="report">Report to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddEmergencyReport(EmergencyReport report)
        {
            _dbContext.Add(report);
            int result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                _cache.Set(report.Id, report, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        /// <summary>
        /// Method to update existing report.
        /// </summary>
        /// <param name="report">Report to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateEmergencyReport(EmergencyReport report)
        {
            _dbContext.Update(report);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing reports.
        /// </summary>
        /// <param name="report">Report to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteEmergencyReport(EmergencyReport report)
        {
            _dbContext.Remove(report);
            await _dbContext.SaveChangesAsync();
        }
    }
}
