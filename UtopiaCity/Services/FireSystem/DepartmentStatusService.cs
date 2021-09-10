using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Services.FireSystem
{
    public class DepartmentStatusService
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentStatusService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DepartmentStatus>> GetDepartments()
        {
            return await _dbContext.DepartmentStatuses.ToListAsync();
        }

        public async Task<DepartmentStatus> GetDepartmentById(string id) 
        {
            return await _dbContext.DepartmentStatuses.FirstOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task AddDepartmentStatus(DepartmentStatus status)
        {
            _dbContext.Add(status);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentStatus(DepartmentStatus status)
        {
            _dbContext.Update(status);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentStatus(DepartmentStatus status)
        {
            _dbContext.Remove(status);
            await _dbContext.SaveChangesAsync();
        }
    }
}
