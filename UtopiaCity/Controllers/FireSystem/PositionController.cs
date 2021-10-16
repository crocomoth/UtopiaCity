using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;
using UtopiaCity.Services.FireSystem;
using UtopiaCity.ViewModels;

namespace UtopiaCity.Controllers.FireSystem
{
    public class PositionController : Controller
    {
        private readonly PositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(PositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Position> positions = await _positionService.GetPositions();
            List<PositionViewModel> positionsViewModel = new List<PositionViewModel>();
            foreach(Position position in positions)
            {
                positionsViewModel.Add(_mapper.Map<PositionViewModel>(position));
            }

            return View("PositionListView", positionsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("PositionCreateView");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionViewModel positionViewModel)
        {
            if(positionViewModel == null)
            {
                return NotFound();
            }

            Position position = _mapper.Map<Position>(positionViewModel);
            await _positionService.CreatePosition(position);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Position position = await _positionService.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }
            PositionViewModel positionViewModel = _mapper.Map<PositionViewModel>(position);
            return View("PositionEditView", positionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PositionViewModel positionViewModel)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            else if (positionViewModel == null)
            {
                return NotFound();
            }

            Position position = _mapper.Map<Position>(positionViewModel);
            await _positionService.UpdatePosition(position);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Position position = await _positionService.GetPositionById(id);
            if (position == null)
            {
                return NotFound();
            }

            PositionViewModel positionViewModel = _mapper.Map<PositionViewModel>(position);
            return View("PositionDeleteView", positionViewModel);
        }

        [HttpPost, ActionName("PositionDeleteView")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Position position = await _positionService.GetPositionById(id);
            if(position == null)
            {
                return NotFound();
            }

            await _positionService.DeletePosition(position);
            return RedirectToAction(nameof(Index));
        }
    }
}
