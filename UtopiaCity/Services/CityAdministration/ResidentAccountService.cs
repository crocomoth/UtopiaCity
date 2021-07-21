using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Services.CityAdministration
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="RersidentAccount"/>
    /// </summary>
    public class ResidentAccountService
    {
        private readonly ApplicationDbContext _dbContext;

        public ResidentAccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="RersidentAccount"/> by Id.
        /// </summary>
        /// <param name="id">Id of account.</param>
        /// <returns>Account if it exists, otherwise null.</returns>
        public async Task<RersidentAccount> GetRersidentAccountById(string id)
        {
            return await _dbContext.RersidentAccount.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all accounts.
        /// </summary>
        /// <returns>List of all existing accounts.</returns>
        public async Task<List<RersidentAccount>> GetRersidentAccounts()
        {
            return await _dbContext.RersidentAccount.ToListAsync();
        }

        /// <summary>
        /// Method to add new accounts.
        /// </summary>
        /// <param name="account">Account to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddRersidentAccount(RersidentAccount account)
        {
            _dbContext.Add(account);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing account.
        /// </summary>
        /// <param name="account">Account to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateRersidentAccount(RersidentAccount account)
        {
            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing accounts.
        /// </summary>
        /// <param name="account">Account to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteRersidentAccount(RersidentAccount account)
        {
            _dbContext.Remove(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
