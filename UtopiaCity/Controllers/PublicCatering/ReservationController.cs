using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.PublicCatering;
using UtopiaCity.Services.PublicCatering.Reservation;


namespace UtopiaCity.Controllers.PublicCatering
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/PublicCatering/Reservation/ReservationsListView.cshtml", await _reservationService.GetReservations());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("~/Views/PublicCatering/Reservation/CreateReservationView.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation newReservation)
        {
            if (!ModelState.IsValid) return View("~/Views/PublicCatering/Reservation/CreateReservationView.cshtml", newReservation);
            await _reservationService.AddReservation(newReservation);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View("~/Views/PublicCatering/Reservation/EditReservationView.cshtml", reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Reservation edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View("~/Views/PublicCatering/Reservation/EditReservationView.cshtml", edited);
            await _reservationService.UpdateReservation(edited);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View("~/Views/PublicCatering/Reservation/DeleteReservationView.cshtml", reservation);
        }

        [HttpPost, ActionName("DeleteRestaurantView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reservation = await _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationService.DeleteReservation(reservation);
            return RedirectToAction(nameof(Index));
        }
    }
}