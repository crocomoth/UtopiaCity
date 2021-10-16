using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Services.FireSystem
{
    public class DepatureToThePlaceService
    {
        private readonly ApplicationDbContext _dbContext;

        public DepatureToThePlaceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DepartureToThePlaceOfFire> GetDepatureById(string id)
        {
            return await _dbContext.DeparturesToThePlaces.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<DepartureToThePlaceOfFire>> GetDepatures()
        {
            return await _dbContext.DeparturesToThePlaces.Include(e => e.Department).ToListAsync();
        }

        public async Task AddDepature(DepartureToThePlaceOfFire depature)
        {
            _dbContext.Add(depature);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepature(DepartureToThePlaceOfFire depature)
        {
            _dbContext.Update(depature);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepature(DepartureToThePlaceOfFire depature)
        {
            _dbContext.Remove(depature);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FireSafetyDepartment>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
