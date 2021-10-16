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
    public class PositionService
    {
        private readonly ApplicationDbContext _dbContext;

        public PositionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<Position>> GetPositions()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public virtual async Task<Position> GetPositionById(string id)
        {
            return await _dbContext.Positions.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<string> GetPositionNameById(string id)
        {
            var posId = await _dbContext.Positions.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return posId.Name;
        }

        public virtual async Task CreatePosition(Position position)
        {
            _dbContext.Add(position);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdatePosition(Position position)
        {
            _dbContext.Update(position);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeletePosition(Position position)
        {
            _dbContext.Remove(position);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<string> GetPositionIdByName(string name)
        {
            var position = await _dbContext.Positions.FirstOrDefaultAsync(d => d.Name.Equals(name));
            return position.Id;
        }

        public virtual async Task<List<string>> GetPositionsNames()
        {
            return await _dbContext.Positions.Select(x => x.Name).ToListAsync();
        }
    }
}
