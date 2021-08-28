using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.HousingSystem;
using UtopiaCity.Services.CityAdministration;
using UtopiaCity.Services.HousingSystem;
using UtopiaCity.ViewModels.HousingSystem;

namespace UtopiaCity.Controllers.HousingSystem
{
    public class HousingSystemController : Controller
    {
        private readonly RealEstateService _realEstateService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly ResidentAccountService _residentAccountService;

        public HousingSystemController(RealEstateService realEstateService, IMailService mailService,
            IMapper mapper, ResidentAccountService residentAccountService)
        {
            _realEstateService = realEstateService;
            _mailService = mailService;
            _mapper = mapper;
            _residentAccountService = residentAccountService;
        }

        public async Task<IActionResult> Index()
        {
            return View("RealEstateListView", await _realEstateService.GetRealEstates());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("DetailsRealEstateView", realEstate);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var residents = await _residentAccountService.GetResidentAccounts();

            var viewModel = new AddRealEstateViewModel
            {
                Residents = residents.Select(x => x.FirstName + " " + x.FamilyName).ToList()
            };

            var items = new List<SelectListItem>();
            foreach (string accountNames in viewModel.Residents)
            {
                items.Add(new SelectListItem() { Text = $"{accountNames}", Value = $"{accountNames}" });
            }
            ViewBag.SelectList = items;
            //List<SelectListItem> items = new List<SelectListItem>();
            //foreach (string accountNames in viewModel.Residents)
            //{
            //    items.Add(new SelectListItem() { Text = $"{accountNames}", Value = $"{accountNames}" });
            //}
            //SelectList selectList = new SelectList(items, "Text");
            //ViewBag.Zb = selectList;
            ModelState.Clear();
            return View("CreateRealEstateView", viewModel);
        }

        //var options = new List<SelectListItem>();

        //foreach (string resident in viewModel.Residents)
        //{
        //    options.Add(new SelectListItem { Text = $"{resident}", Value = $"{resident}" });
        //}

        //SelectList residentNames = new SelectList(viewModel.Residents, "FirstName", "FamilyName");
        //ViewBag.ResidentNames = residentNames;
        [HttpPost]
        public async Task<IActionResult> Create(AddRealEstateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                // Send the message
                _mailService.SendMessage("madiyarkoishibekov@gmail.com",
                        $"{viewModel.Number + " " + viewModel.Street}",
                        $"City Administration");

                ViewBag.UserMessage = "Real Estate is Created!";
                ModelState.Clear();

            }
            RealEstate newEstate = _mapper.Map<RealEstate>(viewModel);
            await _realEstateService.AddRealEstate(newEstate);
            return View("CreateRealEstateView", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("EditRealEstateView", realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RealEstate edited)
        {
            if (id != edited.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _realEstateService.UpdateRealEstate(edited);
                return RedirectToAction(nameof(Index));
            }

            return View("EditRealEstateView", edited);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View("DeleteRealEstateView", realEstate);
        }

        [HttpPost, ActionName("DeleteRealEstateView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var realEstate = await _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            await _realEstateService.DeleteRealEstate(realEstate);
            return RedirectToAction(nameof(Index));
        }
    }
}
