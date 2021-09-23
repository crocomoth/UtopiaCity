using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    public class ServicesForOtherStudents
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public ServicesForOtherStudents(ApplicationDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        /// <summary>
        /// Method to block citizen account for police
        /// </summary>
        /// <param name="userId"> User Id</param>
        public virtual void BlockCitizenAccount(string userId)
        {
            var user = (AppUser)_dbContext.AppUser.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(10);
                user.LockoutEnabled = true;
                _dbContext.SaveChanges();
            }
        }
    }
}
