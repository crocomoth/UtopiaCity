using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Services.FireSystem
{
    public class FireSafetyCheckService
    {
        private readonly ApplicationDbContext _dbContext;

        public FireSafetyCheckService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FireSafetyCheck> GetFireSafetyCheckById(string id)
        {
            return await _dbContext.FireSafetyCheck.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<FireSafetyCheck>> GetFireSafetyChecks() 
        {
            return await _dbContext.FireSafetyCheck.Include(e => e.Employee).ToListAsync();
        }

        public async Task AddFireSafetyCheck(FireSafetyCheck check)
        {
            _dbContext.Add(check);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdadeFireSafetyCheck(FireSafetyCheck check)
        {
            _dbContext.Update(check);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFireSafetyCheck(FireSafetyCheck check)
        {
            _dbContext.Remove(check);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<FireSafetyCheck> GetCheckByIdWithEmployee(string id)
        {
            return await _dbContext.FireSafetyCheck.Include(d => d.Employee).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<EmployeeManagement>> GetEmployees()
        {
            return await _dbContext.EmployeesManagement.ToListAsync();
        }
    }
}
