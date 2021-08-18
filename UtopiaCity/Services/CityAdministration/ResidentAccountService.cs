using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Services.CityAdministration
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="ResidentAccount"/>
    /// </summary>
    public class ResidentAccountService
    {
        private readonly ApplicationDbContext _dbContext;

        public ResidentAccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="ResidentAccount"/> by Id.
        /// </summary>
        /// <param name="id">Id of account.</param>
        /// <returns>Account if it exists, otherwise null.</returns>
        public async Task<ResidentAccount> GetResidentAccountById(string id)
        {
            return await _dbContext.ResidentAccount.Include(a => a.Marriage).FirstAsync(a => a.Id == id);
        }

        /// <summary>
        /// Gets list of all accounts.
        /// </summary>
        /// <returns>List of all existing accounts.</returns>
        public async Task<List<ResidentAccount>> GetResidentAccounts()
        {
            return await _dbContext.ResidentAccount.Include(a => a.Marriage).ToListAsync();
        }

        /// <summary> 
        /// Method to add new accounts.
        /// </summary>
        /// <param name="account">Account to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddResidentAccount(ResidentAccount account)
        {
            _dbContext.Add(account);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing account.
        /// </summary>
        /// <param name="account">Account to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateResidentAccount(ResidentAccount account)
        {
            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing accounts.
        /// </summary>
        /// <param name="account">Account to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteResidentAccount(ResidentAccount account)
        {
            _dbContext.Remove(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
