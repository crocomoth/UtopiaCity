using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Services.CityAdministration
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="Marriage"/>
    /// </summary>
    public class MarriageService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ResidentAccountService _residentAccountService;

        public MarriageService(ApplicationDbContext dbContext, ResidentAccountService residentAccountService)
        {
            _dbContext = dbContext;
            _residentAccountService = residentAccountService;
        }

        /// <summary>
        /// Gets <see cref="Marriage"/> by Id.
        /// </summary>
        /// <param name="id">Id of marriage.</param>
        /// <returns>Marriage if it exists, otherwise null.</returns>
        public async Task<Marriage> GetMarriageById(string id)
        {
            return await _dbContext.Marriage.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets list of all marriages.
        /// </summary>
        /// <returns>List of all existing marriages.</returns>
        public async Task<List<Marriage>> GetMarriages()
        {
            return await _dbContext.Marriage.ToListAsync();
        }

        /// <summary> 
        /// Method to add new marriages.
        /// </summary>
        /// <param name="marriage">Marriage to add.</param>
        /// <returns>Task to await for.</returns>
        public async Task AddMarriage(Marriage marriage)
        {

            _dbContext.Add(marriage);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to update existing marriage.
        /// </summary>
        /// <param name="marriage">Marriage to update.</param>
        /// <returns>Task to await for.</returns>
        public async Task UpdateMarriage(Marriage marriage)
        {
            _dbContext.Update(marriage);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to delete existing marriages.
        /// </summary>
        /// <param name="marriage">Marriage to delete</param>
        /// <returns>Task to await for.</returns>
        public async Task DeleteMarriage(Marriage marriage)
        {
            await ClearAccountMarriageId(marriage);

            _dbContext.Remove(marriage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ClearAccountMarriageId(Marriage marriage)
        {
            var FirstPerson = await _residentAccountService.GetResidentAccountById(marriage.FirstPersonId);
            var SecondPerson = await _residentAccountService.GetResidentAccountById(marriage.SecondPersonId);
            FirstPerson.MarriageId = null;
            SecondPerson.MarriageId = null;
            await _residentAccountService.UpdateResidentAccount(FirstPerson);
            await _residentAccountService.UpdateResidentAccount(SecondPerson);
        }

        public async Task<ViewModel> GetViewModel(string id, Marriage marriage)
        {
            ViewModel viewModel = new ViewModel
            {
                MarriageId = id,
                FirstPersonId = marriage.FirstPersonId,
                SecondPersonId = marriage.SecondPersonId,
                MarriageDate = marriage.MarriageDate,
                ResidentAccounts = await _residentAccountService.GetResidentAccounts()
            };

            return viewModel;
        }

        public async Task<ViewModel> GetNewViewModel()
        {
            ViewModel viewModel = new ViewModel
            {
                ResidentAccounts = await _residentAccountService.GetResidentAccounts(),
                MarriageDate = DateTime.Now
            };
            return viewModel;
        }

        public async Task GetMarriageFromViewAsync(ViewModel viewModel, Marriage marriage)
        {

            ResidentAccount FirstPerson = await _residentAccountService.GetResidentAccountById(viewModel.FirstPersonId);
            ResidentAccount SecondPerson = await _residentAccountService.GetResidentAccountById(viewModel.SecondPersonId);
            marriage.FirstPersonId = viewModel.FirstPersonId;
            marriage.FirstPersonData = $"{FirstPerson.FirstName} {FirstPerson.FamilyName} | {FirstPerson.BirthDate.ToShortDateString()}";
            marriage.SecondPersonId = SecondPerson.Id;
            marriage.SecondPersonData = $"{SecondPerson.FirstName} {SecondPerson.FamilyName} | {SecondPerson.BirthDate.ToShortDateString()}";
            marriage.MarriageDate = viewModel.MarriageDate;
            await UpdateMarriage(marriage);
            FirstPerson.MarriageId = marriage.Id;
            SecondPerson.MarriageId = marriage.Id;
            await _residentAccountService.UpdateResidentAccount(FirstPerson);
            await _residentAccountService.UpdateResidentAccount(SecondPerson);
        }

        public async Task UpdateMarriageByAccount(ResidentAccount account)
        {
            if (account.MarriageId != null)
            {
                var marriage = await GetMarriageById(account.MarriageId);
                if (marriage.FirstPersonId == account.Id)
                {
                    marriage.FirstPersonData = $"{account.FirstName} {account.FamilyName} | {account.BirthDate.ToShortDateString()}";
                    await UpdateMarriage(marriage);
                }
                if (marriage.SecondPersonId == account.Id)
                {
                    marriage.SecondPersonData = $"{account.FirstName} {account.FamilyName} | {account.BirthDate.ToShortDateString()}";
                    await UpdateMarriage(marriage);
                }
            }
        }
    }
}
