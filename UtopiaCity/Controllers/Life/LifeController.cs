using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.Life;
using UtopiaCity.Services.Life;

namespace UtopiaCity.Controllers.Life
{
    public class LifeController : Controller
    {
        private readonly LifeService _service;
        public LifeController(LifeService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event e)
        {
            if (ModelState.IsValid)
            {
                _service.Add(e);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", e);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var e = _service.GetById(id);
            if (e == null)
            {
                return NotFound();
            }

            var eventTypes = Enum.GetValues(typeof(EventType))
                .Cast<EventType>()
                .Select(x => new EventTypeItem { Id = (int)x, Name = x.ToString() });

            var selected = eventTypes.FirstOrDefault(x => x.Id.Equals((int)e.EventType));

            ViewData["select"] = new SelectList(items: eventTypes, selectedValue: selected, dataTextField: nameof(EventTypeItem.Name), dataValueField: nameof(EventTypeItem.Id));

            return View(e);
        }

        [HttpPost]
        public IActionResult Edit(string id, Event e)
        {
            if (id != e.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Update(e);
                return RedirectToAction(nameof(Index));
            }

            return View("Edit", e);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var e = _service.GetById(id);
            if (e == null)
            {
                return NotFound();
            }

            return View(e);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(string id)
        {
            var e = _service.GetById(id);
            if (e == null)
            {
                return NotFound();
            }

            _service.Remove(e);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var e = _service.GetById(id);
            if (e == null)
            {
                NotFound();
            }

            return View(e);
        }
    }
}
