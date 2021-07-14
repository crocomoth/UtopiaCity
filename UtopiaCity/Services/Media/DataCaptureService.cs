using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Models.Media;

namespace UtopiaCity.Services.Media
{
    public class DataCaptureService
    {
        private readonly ApplicationDbContext _dbContext;

        public DataCaptureService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DataCapture>> GetDataCaptures()
        {
            return await _dbContext.DataCapture.ToListAsync();
        }

        public async Task<DataCapture> GetDataCaptureById(string id)
        {
            return await _dbContext.DataCapture.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddDataCapture(DataCapture dataCapture)
        {
            _dbContext.DataCapture.Add(dataCapture);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDataCapture(DataCapture dataCapture)
        {
            _dbContext.DataCapture.Update(dataCapture);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDataCapture(DataCapture dataCapture)
        {
            _dbContext.DataCapture.Remove(dataCapture);
            await _dbContext.SaveChangesAsync();
        }
    }
}
