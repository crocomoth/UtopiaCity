using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
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

        public virtual async Task<EmployeeManagement> GetEmployeeById(string id)
        {
            return await _dbContext.EmployeesManagement.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<EmployeeManagement>> GetEmployees()
        {
            return await _dbContext.EmployeesManagement.Include(d => d.Department)
                                                       .Include(p => p.Position)
                                                       .ToListAsync();
        }

        public virtual async Task AddEmployee(EmployeeManagement employee)
        {
            _dbContext.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateEmployee(EmployeeManagement employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteEmployee(EmployeeManagement employee)
        {
            _dbContext.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<EmployeeManagement> GetEmployeeByIdWithDepartmentAndPosition(string id)
        {
            return await _dbContext.EmployeesManagement.Include(d => d.Department)
                                                       .Include(p => p.Position)
                                                       .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        //public virtual async Task<List<string>> GetEmployeeByEquipment()
        //{
        //    return await _dbContext.EmployeesManagement.Select(e => e.Equipment).ToListAsync();
        //}

        //public virtual async Task<string> GetEmployeeIdByEquipment(string equipment)
        //{
        //    var employee = await _dbContext.EmployeesManagement.FirstOrDefaultAsync(t => t.Equipment.Equals(equipment));
        //    return employee.Id;
        //}

        public virtual async Task<List<FireSafetyDepartment>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public virtual async Task<List<Position>> GetPositions()
        {
            return await _dbContext.Positions.ToListAsync();
        }
    }
}
