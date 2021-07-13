using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;


namespace UtopiaCity.Services.Restaurant
{
    public class RestaurantService
    {
        private readonly ApplicationDbContext _dbContext;

        public RestaurantService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Models.PublicCatering.Restaurant> GetRestaurantById(string id)
        {
            return await _dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<List<Models.PublicCatering.Restaurant>> GetRestaurants()
        {
            return await _dbContext.Restaurants.Include(r =>r.RestaurantType).ToListAsync();
        }
        public async Task AddRestaurant(Models.PublicCatering.Restaurant restaurant)
        {
            _dbContext.Add(restaurant);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRestaurant(Models.PublicCatering.Restaurant restaurant)
        {
            _dbContext.Update(restaurant);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRestaurant(Models.PublicCatering.Restaurant restaurant)
        {
            _dbContext.Remove(restaurant);
            await _dbContext.SaveChangesAsync(); }
    }
}