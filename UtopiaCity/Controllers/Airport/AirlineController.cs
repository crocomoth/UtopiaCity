using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Controllers.Airport
{
    public class AirlineController:Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AirlineController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            var airline = _dbContext.Airlines.ToList();
            return View("AirlinesListView", airline);
        }

        public IActionResult Details(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var airline = _dbContext.Airlines.FirstOrDefault(x => x.Id.Equals(id));
            if(airline is null)
            {
                return NotFound();
            }
            return View("AirlineDetailsView", airline);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("AirlineCreateView");
        }

        [HttpPost]
        public IActionResult Create(Airline airline)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(airline);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("AirlineCreateView", airline);
        }

        [HttpGet]
        public IActionResult Edit (string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var airline = _dbContext.Airlines.FirstOrDefault(x => x.Id.Equals(id));
            if(airline is null)
            {
                return NotFound();
            }
            return View("AirlineEditView", airline);
        }

        [HttpPost]
        public IActionResult Edit(string id, Airline edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Update(edited);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("AirlineEditView", edited);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var airline = _dbContext.Airlines.FirstOrDefault(x => x.Id.Equals(id));

            if(airline is null)
            {
                return NotFound();
            }

            return View("AirlineDeleteView", airline);
        }

        [HttpPost, ActionName("AirlineDeleteView")]
        public IActionResult DeleteConfirmed (string id)
        {
            var airline = _dbContext.Airlines.FirstOrDefault(x => x.Id.Equals(id));

            if(airline is null)
            {
                return NotFound();
            }

            _dbContext.Remove(airline);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
