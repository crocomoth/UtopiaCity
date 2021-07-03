using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class FlightController : Controller
    {
        private ApplicationDbContext _dBcontext;
        public FlightController(ApplicationDbContext dbcontext)
        {
            _dBcontext = dbcontext;
        }
        public IActionResult Index()
        {
            return View(_dBcontext.Flights);
        }

        public IActionResult Details(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return NotFound();
            }
            var flight = _dBcontext.Flights.FirstOrDefault(x => x.Id.Equals(id));
            if (flight is null)
            {
                NotFound();
            }
            return View(flight);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Flight newFlight)
        {
            if (ModelState.IsValid)
            {
                _dBcontext.Add(newFlight);
                _dBcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(newFlight);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var flight = _dBcontext.Flights.FirstOrDefault(x => x.Id.Equals(id));
            if (flight is null)
            {
                NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        public IActionResult Edit(string id, Flight edited)
        {
            if (id != edited.Id.ToString())
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _dBcontext.Update(edited);
                _dBcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(edited);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                NotFound();
            }
            var flight = _dBcontext.Flights.FirstOrDefault(x => x.Id.Equals(id));
            if (flight is null)
            {
                NotFound();
            }
            return View(flight);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _dBcontext.Flights.FirstOrDefault(x => x.Id.Equals(id));
            if (flight is null)
            {
                NotFound();
            }
            _dBcontext.Remove(flight);
            _dBcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
