using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class CompanyAppService
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyAppService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<Company>> GetAll()
        {
            return await dbContext.Companies
                .Include(s => s.Bank)
                .Include(x => x.CompanyStatus).ToListAsync();
        }

        public async Task<Company> GetById(string id)
        {
            return await dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task Create(Company company)
        {
            dbContext.Add(company);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Company company)
        {
            company.IIK.ToUpper();
            dbContext.Update(company);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Company company)
        {
            dbContext.Remove(company);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Bank>> GetAllBank()
        {
            return await dbContext.Banks.ToListAsync();
        }

        public async Task<List<CompanyStatus>> GetAllCompanyStatus()
        {
            return await dbContext.CompanyStatuses.ToListAsync();
        }
    }
}
