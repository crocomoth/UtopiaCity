using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.PublicCatering;
using UtopiaCity.Services.Restaurant;


namespace UtopiaCity.Controllers.PublicCatering
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("RestaurantsListView", await _restaurantService.GetRestaurants());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateRestaurantView");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Restaurant newRestaurant)
        {
            if (!ModelState.IsValid) return View("CreateRestaurantView", newRestaurant);
            await _restaurantService.AddRestaurant(newRestaurant);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                NotFound();
            }

            return View("DetailsRestaurantView", restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View("EditRestaurantView", restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Restaurant edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View("EditRestaurantView", edited);
            await _restaurantService.UpdateRestaurant(edited);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View("DeleteRestaurantView", restaurant);
        }

        [HttpPost, ActionName("DeleteRestaurantView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var restaurant = await _restaurantService.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            await _restaurantService.DeleteRestaurant(restaurant);
            return RedirectToAction(nameof(Index));
        }
    }
}