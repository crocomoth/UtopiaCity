using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class VacancyAppService
    {
        private readonly ApplicationDbContext _dbContext;

        public VacancyAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Vacancy>> GetAll()
        {
            return await _dbContext.Vacancies
                .Include(x => x.Profession)
                .Include(s => s.Company).ToListAsync();
        }

        public async Task<Vacancy> GetById(string id)
        {
            return await _dbContext.Vacancies.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Vacancy vacancy)
        {
            _dbContext.Add(vacancy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Vacancy vacancy)
        {
            _dbContext.Update(vacancy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Vacancy vacancy)
        {
            _dbContext.Remove(vacancy);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<List<Profession>> GetAllProfession()
        {
            return await _dbContext.Professions.ToListAsync();
        }
    }
}
