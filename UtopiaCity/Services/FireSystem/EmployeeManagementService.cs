using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Services.FireSystem
{
    public class EmployeeManagementService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeManagementService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeManagement> GetEmployeeById(string id)
        {
            return await _dbContext.EmployeesManagement.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<EmployeeManagement>> GetEmployees()
        {
            return await _dbContext.EmployeesManagement.ToListAsync();
        }

        public async Task AddEmployee(EmployeeManagement employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployee(EmployeeManagement employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(EmployeeManagement employee)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
