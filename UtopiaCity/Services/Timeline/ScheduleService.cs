using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Services.Timeline
{
    public class ScheduleService
    {
        private readonly ApplicationDbContext _dbContext;

        public ScheduleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// SHOW LIST OF EVENT
        /// </summary>
        /// <returns>LIST</returns>
        public async Task<List<ScheduleModel>> GetList() => await _dbContext.ScheduleModel.ToListAsync();


    }
}
