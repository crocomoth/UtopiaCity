using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Services.Business.Dtos;
using UtopiaCity.Services.CityAdministration;

namespace UtopiaCity.Services.Business
{
    public class ResumeAppService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ResidentAccountService _residentAccountService;
        public ResumeAppService(ApplicationDbContext dbContext, ResidentAccountService residentAccountService)
        {
            _dbContext = dbContext;
            _residentAccountService = residentAccountService;
        }

        public async Task<List<Resume>> GetAll(string filter)
        {
            return await _dbContext.Resumes
                .Include(s => s.ResidentAccount)
                .Include(s => s.Profession)
                .Where(s => string.IsNullOrEmpty(filter) ? true : s.Profession.Name.ToLower().Contains(filter.ToLower())  
                    || s.Salary.ToString().Contains(filter)  
                    || s.ResidentAccount.FirstName.ToLower().Contains(filter.ToLower())
                    || s.ResidentAccount.FamilyName.ToLower().Contains(filter.ToLower())).ToListAsync();
        }

        public async Task<Resume> GetById(string id)
        {
            return await _dbContext.Resumes.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Resume resume)
        {
            _dbContext.Add(resume);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Resume resume)
        {
            _dbContext.Update(resume);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Resume resume)
        {
            _dbContext.Remove(resume);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ResumeResidentAccountTableDto>> GetAllResidentAccount()
        {
            var dbList = await _dbContext.ResidentAccount.ToListAsync();
            var results = new List<ResumeResidentAccountTableDto>();
            foreach(var x in dbList)
            {
                var res = new ResumeResidentAccountTableDto()
                {
                    Id = x.Id,
                    FIO = x.FirstName + " " + x.FamilyName
                };

                results.Add(res);
            }

            return results;
        }

        public async Task<List<Profession>> GetAllProfession()
        {
            return await _dbContext.Professions.ToListAsync();
        }
    }
}
