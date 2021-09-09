using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.HousingSystem;

namespace UtopiaCity.Services.HousingSystem
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="RealEstate"/>.
    /// </summary>
    public class RealEstateService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public RealEstateService(ApplicationDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        /// <summary>
        /// Gets <see cref="RealEstate"/> by Id.
        /// </summary>
        /// <param name="id">Id of real estate.</param>
        /// <returns>real estate if it exists, otherwise null.</returns>
        public async Task<RealEstate> GetRealEstateById(string id)
        {
            if (_cache.TryGetValue(id, out RealEstate estate))
            {
                return estate;
            }

            var notCached =  await _dbContext.RealEstate.FirstOrDefaultAsync(x => x.Id.Equals(id));
            _cache.Set(id, notCached, new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return notCached;
        }

        public virtual async Task<List<RealEstate>> GetRealEstates()
        {
            return await _dbContext.RealEstate.ToListAsync();
        }

        public async Task AddRealEstate(RealEstate realEstate)
        {
            _dbContext.Add(realEstate);
            int result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                _cache.Set(realEstate.Id, realEstate, new MemoryCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRealEstate(RealEstate realEstate)
        {
            _dbContext.Update(realEstate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRealEstate(RealEstate realEstate)
        {
            _dbContext.Remove(realEstate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
