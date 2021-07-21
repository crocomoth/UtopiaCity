using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;

namespace UtopiaCity.Services.HousingSystem
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="RealEstate"/>
    /// </summary>
    public class HousingSystemService
    {
        private readonly ApplicationDbContext _dbContext;

        public HousingSystemService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="RealEstate"/> by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estate if it exits, otherwise null.</returns>
        public async Task<RealEstate> GetRealEstateById(string id)
        {
            return await _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<RealEstate>> GetRealEstatesList()
        {
            return await _dbContext.RealEstate.ToListAsync();
        }

        public async Task AddRealEstate(RealEstate estate)
        {
            _dbContext.Add(estate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRealEstate(RealEstate estate)
        {
            _dbContext.Update(estate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRealEstate(RealEstate estate)
        {
            _dbContext.Remove(estate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
