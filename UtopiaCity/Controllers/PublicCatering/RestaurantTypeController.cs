using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.PublicCatering;
using UtopiaCity.Services.RestaurantType;


namespace UtopiaCity.Controllers.PublicCatering
{
    public class RestaurantTypeController : Controller
    {
        private readonly RestaurantTypeService _restaurantTypeService;

        public RestaurantTypeController(RestaurantTypeService restaurantTypeService)
        {
            _restaurantTypeService = restaurantTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("RestaurantsTypeListView", await _restaurantTypeService.GetRestaurantTypes());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateRestaurantTypeView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantType newRestaurantType)
        {
            if (!ModelState.IsValid) return View("CreateRestaurantTypeView", newRestaurantType);
            await _restaurantTypeService.AddRestaurantType(newRestaurantType);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurantType = await _restaurantTypeService.GetRestaurantTypeById(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            return View("EditRestaurantTypeView", restaurantType);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RestaurantType edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View("EditRestaurantTypeView", edited);
            await _restaurantTypeService.UpdateRestaurantType(edited);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var restaurantType = await _restaurantTypeService.GetRestaurantTypeById(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            return View("DeleteRestaurantTypeView", restaurantType);
        }

        [HttpPost, ActionName("DeleteRestaurantTypeView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var restaurantType = await _restaurantTypeService.GetRestaurantTypeById(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            await _restaurantTypeService.DeleteRestaurantType(restaurantType);
            return RedirectToAction(nameof(Index));
        }
    }
}