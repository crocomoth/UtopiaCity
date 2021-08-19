using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class EmployeeAppService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeAppService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employees
                .Include(s => s.Profession)
                .Include(x => x.Company).ToListAsync();
        }

        public async Task<Employee> GetById(string id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Employee employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Employee employee)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Profession>> GetAllProfession()
        {
            return await _dbContext.Professions.ToListAsync();
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _dbContext.Companies.ToListAsync();
        }
    }
}
