using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;

namespace UtopiaCity.Services.FireSystem
{
    public class FireMessageService
    {
        private readonly ApplicationDbContext _dbContext;

        public FireMessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FireMessage> GetFireMessageById(string id)
        {
            return await _dbContext.FireMessage.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<FireMessage>> GetFireMessages()
        {
            return await _dbContext.FireMessage.ToListAsync();
        }

        public async Task AddFireMessage(FireMessage message)
        {
            _dbContext.Add(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFireMessage(FireMessage message)
        {
            _dbContext.Update(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFireMessage(FireMessage message)
        {
            _dbContext.Remove(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}
