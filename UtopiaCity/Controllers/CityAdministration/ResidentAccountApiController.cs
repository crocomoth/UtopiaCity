using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtopiaCity.Models.CityAdministration;
using UtopiaCity.Services.CityAdministration;
using System.Linq;
using System.Collections.Generic;

namespace UtopiaCity.Controllers.CityAdministration
{
    [ApiController]
    [Route("[controller]")]
    public class ResidentAccountApiController : ControllerBase
    {
        private readonly ResidentAccountService _residentAccountService;
        private readonly MarriageService _marriageService;

        public ResidentAccountApiController(ResidentAccountService residentAccountService, MarriageService marriageService)
        {
            _residentAccountService = residentAccountService;
            _marriageService = marriageService;
        }

        // view list of accounts

        public async Task<ActionResult<IEnumerable<ResidentAccount>>> GetAccounts()
        {
            var accounts = await _residentAccountService.GetResidentAccounts();
            return accounts;
        }

        // get account by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentAccount>> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                NotFound();
            }

            return account;
        }

        // create new account
        [HttpPost]
        public async Task<ActionResult<ResidentAccount>> Create(ResidentAccount newAccount)
        {
            if (newAccount == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _residentAccountService.AddResidentAccount(newAccount);
            }
            else
            {
                return BadRequest(ModelState);
            }

            return Ok(newAccount);
        }

        // update account
        [HttpPut]
        public async Task<ActionResult<ResidentAccount>> Edit(ResidentAccount edited)
        {
            var accounts = await _residentAccountService.GetResidentAccounts();

            if (edited == null)
            {
                return BadRequest();
            }

            if (!accounts.Any(x => x.Id == edited.Id))
            {
                return NotFound();
            }

            await _residentAccountService.UpdateResidentAccount(edited);
            await _marriageService.UpdateMarriageByAccount(edited);

            return Ok(edited);
        }

        //delete account
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResidentAccount>> DeleteConfirmed(string id)
        {
            var account = await _residentAccountService.GetResidentAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            if (account.MarriageId != null)
            {
                await _marriageService.DeleteMarriage(await _marriageService.GetMarriageById(account.MarriageId));
            }

            await _residentAccountService.DeleteResidentAccount(account);
            return Ok(account);
        }
    }
}
