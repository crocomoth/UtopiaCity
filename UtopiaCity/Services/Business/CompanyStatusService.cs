using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class CompanyStatusService
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyStatusService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompanyStatus>> GetAll()
        {
            return await _dbContext.CompanyStatuses.ToListAsync();
        }

        public async Task<CompanyStatus> GetById(string id)
        {
            return await _dbContext.CompanyStatuses.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(CompanyStatus status)
        {
            _dbContext.Add(status);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(CompanyStatus status)
        {
            _dbContext.Update(status);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(CompanyStatus status)
        {
            _dbContext.Remove(status);
            await _dbContext.SaveChangesAsync();
        }
    }
}
