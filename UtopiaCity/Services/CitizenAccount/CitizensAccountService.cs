using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    /// <summary>
    /// Class to handle find AppUserBy ID <see cref="AppUser"/>
    /// </summary>
    public class CitizensAccountService
    {
        private readonly ApplicationDbContext _dbContext;
        public CitizensAccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="AppUser"/> by Id.
        /// </summary>
        /// <param name="id">Id of User.</param>
        /// <returns>User if it exists, otherwise null.</returns>
        public async Task<AppUser> GetUserById(string id)
        {
            return (AppUser)await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
