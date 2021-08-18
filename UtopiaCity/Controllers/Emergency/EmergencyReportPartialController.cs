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

        [HttpPost]
        public ActionResult SomeAction(string name)
        {
            var result = _context.EmergencyCertificate.ToList();

            return PartialView("EmergencyCertificatePartial", result);
        }
    }
}
