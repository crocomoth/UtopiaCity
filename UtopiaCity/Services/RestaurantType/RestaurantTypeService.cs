using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;

namespace UtopiaCity.Services.RestaurantType
{
    public class RestaurantTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public RestaurantTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Models.PublicCatering.RestaurantType> GetRestaurantTypeById(string id)
        {
            return await _dbContext.RestaurantTypes.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<List<Models.PublicCatering.RestaurantType>> GetRestaurantTypes()
        {
            return await _dbContext.RestaurantTypes.ToListAsync();
        }
        public async Task AddRestaurantType(Models.PublicCatering.RestaurantType restaurantType)
        {
            _dbContext.Add(restaurantType);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRestaurantType(Models.PublicCatering.RestaurantType restaurantType)
        {
            _dbContext.Update(restaurantType);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRestaurantType(Models.PublicCatering.RestaurantType restaurantType)
        {
            _dbContext.Remove(restaurantType);
            await _dbContext.SaveChangesAsync(); }
    }
}