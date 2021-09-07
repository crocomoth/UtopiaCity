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
        /// <summary>
        /// Gets the list of accounts
        /// </summary>
        /// <returns>The list of all accounts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentAccount>>> Get()
        {
            var accounts = await _residentAccountService.GetResidentAccounts();
            return accounts;
        }

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The account by id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentAccount>> Get(string id)
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

        /// <summary>
        /// Creates new account
        /// </summary>
        /// <param name="newAccount"></param>
        /// <returns>Newly created account</returns>
        [HttpPost]
        public async Task<ActionResult<ResidentAccount>> Post(ResidentAccount newAccount)
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

        /// <summary>
        /// Updates an account
        /// </summary>
        /// <param name="edited"></param>
        /// <returns>Updated account</returns>
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

        /// <summary>
        /// Deletes account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted account</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResidentAccount>> Delete(string id)
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
