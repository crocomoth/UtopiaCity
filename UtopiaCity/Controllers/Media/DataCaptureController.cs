using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.Media;
using UtopiaCity.Services.Media;

namespace UtopiaCity.Controllers.Emergency
{
    public class DataCaptureController : Controller
    {
        private readonly DataCaptureService _dataCaptureService;

        public DataCaptureController(DataCaptureService dataCaptureService)
        {
            _dataCaptureService = dataCaptureService;
        }

        // view list of reports
        public async Task<IActionResult> Index()
        {
            var a = View("DataCaptureListView", await _dataCaptureService.GetDataCaptures());
            return a;
        }

        // get specific item by id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var data = await _dataCaptureService.GetDataCaptureById(id);
            if (data == null)
            {
                NotFound();
            }

            return View("DetailsDataCaptureView", data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("CreateDataCaptureView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataCapture newReport)
        {
            if (ModelState.IsValid)
            {
                await _dataCaptureService.AddDataCapture(newReport);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateDataCaptureView", newReport);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var data = await _dataCaptureService.GetDataCaptureById(id);
            if (data is null)
            {
                return NotFound();
            }

            return View("EditDataCaptureView", data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, DataCapture edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _dataCaptureService.UpdateDataCapture(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditDataCaptureView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var data = await _dataCaptureService.GetDataCaptureById(id);
            if (data is null)
            {
                return NotFound();
            }

            return View("DeleteDataCaptureView", data);
        }

        [HttpPost, ActionName("DeleteDataCaptureView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var data = await _dataCaptureService.GetDataCaptureById(id);
            if (data is null)
            {
                return NotFound();
            }

            await _dataCaptureService.DeleteDataCapture(data);
            return RedirectToAction(nameof(Index));
        }
    }
}
