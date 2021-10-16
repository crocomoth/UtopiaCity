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
    public class TransportManagementService
    {
        private readonly ApplicationDbContext _dbContext;

        public TransportManagementService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<TransportManagement>> GetTrasports()
        {
            return await _dbContext.TransportsManagement.Include(d => d.Department).ToListAsync();
        }

        public virtual async Task<TransportManagement> GetTrasportById(string id)
        {
            return await _dbContext.TransportsManagement.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TransportManagement> GetTransportByIdWithDepartment(string id)
        {
            return await _dbContext.TransportsManagement.Include(d => d.Department)
                                                        .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task AddTransport(TransportManagement transport)
        {
            _dbContext.Add(transport);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateTrasnport(TransportManagement transport)
        {
            _dbContext.Update(transport);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteTransport(TransportManagement transport)
        {
            _dbContext.Remove(transport);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<string>> GetTrasportsByType()
        {
            return await _dbContext.TransportsManagement.Select(t => t.TypeOfFireCar).ToListAsync();
        }

        public virtual async Task<string> GetTrasportsIdByType(string typeOfFireCar)
        {
            var transport =  await _dbContext.TransportsManagement.FirstOrDefaultAsync(t => t.TypeOfFireCar.Equals(typeOfFireCar));
            return transport.Id;
        }

        public async Task<List<FireSafetyDepartment>> GetDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
