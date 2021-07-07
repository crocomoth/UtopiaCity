using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportController : Controller
    {
        private readonly EmergencyReportService _emergencyReportService;

        public EmergencyReportController(EmergencyReportService emergencyReportService)
        {
            _emergencyReportService = emergencyReportService;
        }

        // view list of reports
        public async Task<IActionResult> Index()
        {
            return View("EmergencyReportListView", await _emergencyReportService.GetEmergencyReports());
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _emergencyReportService.GetEmergencyReportById(id);
            if (report == null)
            {
                NotFound();
            }

            return View("DetailsEmergencyReportView", report);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateEmergencyReportView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmergencyReport newReport)
        {
            if (ModelState.IsValid)
            {
                await _emergencyReportService.AddEmergencyReport(newReport);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateEmergencyReportView", newReport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _emergencyReportService.GetEmergencyReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("EditEmergencyReportView", report);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EmergencyReport edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _emergencyReportService.UpdateEmergencyReport(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditEmergencyReportView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var report = await _emergencyReportService.GetEmergencyReportById(id);
            if (report == null)
            {
                return NotFound();
            }

            return View("DeleteEmergencyReportView", report);
        }

        [HttpPost, ActionName("DeleteEmergencyReportView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var report = await _emergencyReportService.GetEmergencyReportById(id);
            if (report == null)
            {
                // TODO rewrite?
                return NotFound();
            }

            await _emergencyReportService.DeleteEmergencyReport(report);
            return RedirectToAction(nameof(Index));
        }
    }
}
