using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
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

        public async Task<TransportManagement> GetTrasportById(string id)
        {
            return await _dbContext.TransportsManagements.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<TransportManagement>> GetTrasports()
        {
            return await _dbContext.TransportsManagements.ToListAsync();
        }

        public async Task AddTransport(TransportManagement transport)
        {
            _dbContext.Add(transport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTrasnport(TransportManagement transport)
        {
            _dbContext.Update(transport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransport(TransportManagement transport)
        {
            _dbContext.Remove(transport);
            await _dbContext.SaveChangesAsync();
        }
    }
}
