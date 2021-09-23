using System.Collections.Generic;
using System.Linq;
using UtopiaCity.Controllers.CitizenAccount;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    /// <summary>
    /// Class to handle operations for <see cref="CitizenFinanceController"/>
    /// </summary>
    public class CitizenFinanceService
    {
        private readonly ApplicationDbContext _dbContext;

        public CitizenFinanceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Create and save transacton.
        /// </summary>
        /// <param name="transactionToTopUp">Object type TransactionToTopUpViewModel.</param>
        /// <param name="appUser">Current app user.</param>

        public virtual void CreateTransactionAndSave(TransactionToTopUpViewModel transactionToTopUp, AppUser appUser)
        {
            Transaction userTransaction = new Transaction()
            {
                Amount = transactionToTopUp.Amount,
                Description = "Top up balance",
                Date = transactionToTopUp.Date,
                UserId = appUser.Id
            };
            _dbContext.Add(userTransaction);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Create and save transacton.
        /// </summary>
        /// <param name="transactionToTopUp">Object type TransactionToBuyViewModel.</param>
        /// <param name="appUser">Current app user.</param>
        public virtual void CreateTransactionAndSave(TransactionToBuyViewModel transactionToBuy, AppUser appUser)
        {
            Transaction userTransaction = new Transaction()
            {
                Amount = transactionToBuy.Amount,
                Description = transactionToBuy.DescriptionOfThePurchase,
                Date = transactionToBuy.Date,
                UserId = appUser.Id
            };
            _dbContext.Add(userTransaction);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Get user purchases.
        /// </summary>
        public virtual List<Transaction> GetPurchases(string userId)
        {
            return _dbContext.Transactions.Where(x => x.Description != "Top up balance").OrderBy(x => x.Date).Where(x => x.UserId == userId).ToList();
        }
        /// <summary>
        /// Get user transaction history include purchases and top up balance.
        /// </summary>
        public virtual List<Transaction> GetTransactionHistory(string userId)
        {
            return _dbContext.Transactions.Where(x => x.UserId == userId).OrderBy(x => x.Date).ToList();
        }
    }
}
