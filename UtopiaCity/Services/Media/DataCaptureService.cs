using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Helpers;
using UtopiaCity.Models.Media;

namespace UtopiaCity.Services.Media
{
    public class DataCaptureService
    {
        private ApplicationDbContext _dbContext;
        public DataCaptureService(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public virtual async Task<List<DataCapture>> GetAllDataCaptures()
        {
            return await _dbContext.DataCaptures.Include(d => d.Employee).ToListAsync();
        }
        
        public async Task<DataCapture> GetDataCaptureById(string id)
        {
            return await _dbContext.DataCaptures
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddDataCapture(DataCapture dataCapture)
        {
            if (await _dbContext.DataCaptures.AnyAsync(x => x.Id == dataCapture.Id))
                throw new AppException("Advertisment with this id is already exists");

            await _dbContext.DataCaptures.AddAsync(dataCapture);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDataCaptureById(DataCapture dataCapture)
        {
            if (!await _dbContext.DataCaptures.AnyAsync(x => x.Id == dataCapture.Id))
                throw new AppException("Advertisment with this id does not exist");

            _dbContext.DataCaptures.Update(dataCapture);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDataCaptureById(string id)
        {
            var dataCapture = await _dbContext.DataCaptures.FindAsync(id);

            if (dataCapture is null)
            {
                throw new AppException("Advertisment with this id does not exist");
            }

            _dbContext.DataCaptures.Remove(dataCapture);
            await _dbContext.SaveChangesAsync();
        }
    }
}
