using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TimelineModel;

namespace UtopiaCity.Services.Timeline
{
    public class PermitedConditonsService
    {
        private readonly ApplicationDbContext _dbContext;

        public PermitedConditonsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// SHOW LIST OF EVENT
        /// </summary>
        /// <returns>LIST</returns>
        public async Task<List<PermitedModel>> GetList()
        {
            return await _dbContext.PermitedModel.ToListAsync();
        }
    }
}
