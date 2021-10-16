using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
using UtopiaCity.Models.FireSystem.ManagerSystemTransportAndEmployees;

namespace UtopiaCity.Services.FireSystem
{
    public class FireSafetyDepartmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public FireSafetyDepartmentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<FireSafetyDepartment>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public virtual async Task<FireSafetyDepartment> GetDepartmentById(string id)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(d => d.Id.Equals(id));
        }

        public virtual async Task CreateDepartment(FireSafetyDepartment department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateDepartment(FireSafetyDepartment department)
        {
            _dbContext.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteDepartment(FireSafetyDepartment department)
        {
            _dbContext.Remove(department);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<FireSafetyDepartment> GetDepartmentsByNames(string name)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public virtual async Task<List<string>> GetDepartmentsIds(string id)
        {
            return await _dbContext.Departments.Select(i => i.Id).ToListAsync();
        }

        public virtual async Task<string> GetDepartmentIdByName(string name)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.Name.Equals(name));
            return department.Id;
        }

        //public async Task<List<EmployeeManagement>> GetEmployees()
        //{
        //    return await _dbContext.EmployeesManagement.ToListAsync();
        //}

        //public async Task<List<TransportManagement>> GetTransports()
        //{
        //    return await _dbContext.TransportsManagement.ToListAsync();
        //}

        //public async Task<List<DepartureToThePlaceOfFire>> GetDepartures()
        //{
        //    return await _dbContext.DeparturesToThePlaces.ToListAsync();
        //}

        public virtual async Task<List<string>> GetDepartmentsNames()
        {
            return await _dbContext.Departments.Select(x => x.Name).ToListAsync();
        }
    }
}
