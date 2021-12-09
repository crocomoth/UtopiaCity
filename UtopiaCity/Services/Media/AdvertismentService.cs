using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Helpers;
using UtopiaCity.Models.Media;

namespace UtopiaCity.Services.Media
{
    public class AdvertismentService
    {
        private readonly ApplicationDbContext _dbContext;

        public AdvertismentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Advertisment>> GetAllAdvertisments()
        {
            return await _dbContext.Advertisments.Include(a => a.Employee).Include(a => a.User).ToListAsync();
        }

        public async Task<Advertisment> GetAdvertismentById(string id)
        {

            return await _dbContext.Advertisments
                .Include(a => a.Employee)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAdvertisment(Advertisment advertisment)
        {
            if (await _dbContext.Advertisments.AnyAsync(x => x.Id == advertisment.Id))
                throw new AppException("Advertisment with this id already exists");

            await _dbContext.Advertisments.AddAsync(advertisment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAdvertismentById(Advertisment advertisment)
        {
            if (!await _dbContext.Advertisments.AnyAsync(x => x.Id == advertisment.Id))
                throw new AppException("Advertisment with this id does not exist");
            
            _dbContext.Advertisments.Update(advertisment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAdvertismentById(string id)
        {
            var advertisment = await _dbContext.Advertisments.FindAsync(id);

            if (advertisment is null)
            {
                throw new AppException("Advertisment with this id does not exist");
            }

            _dbContext.Advertisments.Remove(advertisment);
            await _dbContext.SaveChangesAsync();
        }

    }
}
