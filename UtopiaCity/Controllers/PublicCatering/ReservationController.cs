using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UtopiaCity.Data;
using UtopiaCity.Models.PublicCatering;
using UtopiaCity.Services.Reservation;


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
            return View("ReservationsListView", await _reservationService.GetReservations());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateReservationView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation newReservation)
        {
            if (!ModelState.IsValid) return View("CreateReservationView", newReservation);
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

            return View("EditReservationView", reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Reservation edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View("EditReservationView", edited);
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

            return View("DeleteReservationView", reservation);
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