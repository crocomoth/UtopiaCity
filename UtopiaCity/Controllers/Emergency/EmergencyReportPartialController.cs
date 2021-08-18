using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UtopiaCity.Data;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportPartialController : Controller
    {
        private ApplicationDbContext _context;

        public EmergencyReportPartialController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("TestView");
        }

        [HttpPost]
        public ActionResult SomeAction()
        {
            var result = _context.EmergencyCertificate.ToList();

            return Ok("From server");
        }
    }
}
