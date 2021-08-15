using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business;

namespace UtopiaCity.Services.Business
{
    public class BankService
    {
        private readonly ApplicationDbContext _dbContext;

        public BankService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Bank>> GetAll()
        {
            return await _dbContext.Banks.ToListAsync();
        }

        public async Task<Bank> GetById(string id)
        {
            return await _dbContext.Banks.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Create(Bank bank)
        {
            bank.BIK = bank.BIK.ToUpper();
            _dbContext.Add(bank);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Bank bank)
        {
            bank.BIK = bank.BIK.ToUpper();
            _dbContext.Update(bank);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Bank bank)
        {
            _dbContext.Remove(bank);
            await _dbContext.SaveChangesAsync();
        }
    }
}
