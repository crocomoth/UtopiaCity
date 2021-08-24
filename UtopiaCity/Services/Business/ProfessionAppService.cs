using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class ProfessionAppService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfessionAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Profession>> GetAll()
        {
            return await _dbContext.Professions.ToListAsync();
        }

        public async Task<Profession> GetById(string id)
        {
            return await _dbContext.Professions.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Profession profession)
        {
            _dbContext.Add(profession);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Profession profession)
        {
            _dbContext.Update(profession);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Profession profession)
        {
            _dbContext.Remove(profession);
            await _dbContext.SaveChangesAsync();
        }
    }
}
