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
    public class FireSafetyCheckRequestService
    {
        private readonly ApplicationDbContext _dbContext;

        public FireSafetyCheckRequestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FireSafetyCheckRequest> GetFireSafetyCheckRequestById(string id)
        {
            return await _dbContext.FireSafetyCheckRequests.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<FireSafetyCheckRequest>> GetFireSafetyCheckRequests()
        {
            return await _dbContext.FireSafetyCheckRequests.ToListAsync();
        }

        public async Task<FireSafetyCheckRequest> AddFireSafetyCheckRequest(FireSafetyCheckRequest check)
        {
            _dbContext.Add(check);
            await _dbContext.SaveChangesAsync();
            return check;
        }

        public async Task UpdadeFireSafetyCheckRequest(FireSafetyCheckRequest check)
        {
            _dbContext.Update(check);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFireSafetyCheckRequest(FireSafetyCheckRequest check)
        {
            _dbContext.Remove(check);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeManagement> GetCanCheckEmployee()
        {
            var employee = await _dbContext.EmployeesManagement.Where(e => e.CanCheck == true).FirstAsync();
            if(employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }
    }
}
