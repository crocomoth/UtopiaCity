using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicCatering;


namespace UtopiaCity.Controllers.PublicCatering
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RestaurantController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var restaurants = await _dbContext.Restaurants.Include(r =>r.RestaurantType).ToListAsync();
            return View("~/Views/PublicCatering/Restaurant/RestaurantsListView.cshtml", restaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var restaurantTypes = await _dbContext.RestaurantTypes.ToListAsync();
            ViewBag.RestaurantTypes = restaurantTypes;
            return View("~/Views/PublicCatering/Restaurant/CreateRestaurantView.cshtml");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant newRestaurant)
        {
            if (newRestaurant == null) return RedirectToAction("Index");
            await _dbContext.Restaurants.AddAsync(newRestaurant);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var restaurantTypes = await _dbContext.RestaurantTypes.ToListAsync();
            ViewBag.RestaurantTypes = new SelectList(restaurantTypes, "Id", "Name");
            
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(t => t.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return View("~/Views/PublicCatering/Restaurant/EditRestaurantView.cshtml", restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id, Restaurant edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View("~/Views/PublicCatering/Restaurant/EditRestaurantView.cshtml", edited);
            _dbContext.Update(edited);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var restaurant = await _dbContext.Restaurants.Include(r => r.RestaurantType).FirstOrDefaultAsync(t => t.Id == id);
            if (restaurant != null)
            {
                return View("~/Views/PublicCatering/Restaurant/DetailsRestaurantView.cshtml", restaurant);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(t => t.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View("~/Views/PublicCatering/Restaurant/DeleteRestaurantView.cshtml", restaurant);
        }

        [HttpPost, ActionName("DeleteRestaurantView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var restaurant = await _dbContext.Restaurants.FirstOrDefaultAsync(t => t.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            _dbContext.Remove(restaurant);
            await _dbContext.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }
    }
}