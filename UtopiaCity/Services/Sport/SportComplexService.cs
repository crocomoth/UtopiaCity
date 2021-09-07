using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Sport;

namespace UtopiaCity.Services.Sport
{
    /// <summary>
    /// Class to handle basic CRUD operations for <see cref="SportComplex"/>
    /// </summary>
    public class SportComplexService
    {
        private readonly ApplicationDbContext _dbContext;

        public SportComplexService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of all sport complexes.
        /// </summary>
        /// <returns>List of all existing sport complexes.</returns>
        public virtual async Task<List<SportComplex>> GetAllSportComplexes()
            => await _dbContext.SportComplex
                .ToListAsync();

        /// <summary>
        /// Gets <see cref="SportComplex"/> by Id.
        /// </summary>
        /// <param name="id">Id of sport complex.</param>
        /// <returns>Sport complex if it exists, otherwise null.</returns>
        public virtual async Task<SportComplex> GetSportComplexById(string id)
            => await _dbContext.SportComplex
                .FirstOrDefaultAsync(x => x.SportComplexId.Equals(id));

        /// <summary>
        /// Method for adding new sport complex to database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for adding.</param>
        public virtual async Task AddSportComplexToDb(SportComplex sportComplex)
        {
            _dbContext.Add(sportComplex);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method for removing sport complex from database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for removing.</param>
        public virtual async Task RemoveSportComplexFromDb(SportComplex sportComplex)
        {
            _dbContext.Remove(sportComplex);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method for updating sport complex in database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for updating.</param>
        public virtual async Task UpdateSportComplexInDb(SportComplex sportComplex)
        {
            _dbContext.SportComplex.Update(sportComplex);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets list of sport complexes' titles.
        /// </summary>
        /// <returns>List of all existing sport complexes' titles.</returns>
        public virtual async Task<List<string>> GetAllSportComplexesTitles()
            => await _dbContext.SportComplex
                .Select(x => x.Title)
                .ToListAsync();

        /// <summary>
        /// Gets <see cref="SportComplex"/> by Title.
        /// </summary>
        /// <param name="title">Title of sport complex.</param>
        /// <returns>Sport complex if it exists, otherwise null.</returns>
        public virtual async Task<SportComplex> GetSportComplexByTitle(string title)
            => await _dbContext.SportComplex
                .FirstOrDefaultAsync(x => x.Title.Equals(title));

        /// <summary>
        /// Gets <see cref="SportComplex.SportComplexId"/> by Title.
        /// </summary>
        /// <param name="title">Title of sport complex.</param>
        /// <returns>Sport complex's id if it exists, otherwise null.</returns>
        public virtual async Task<string> GetSportComplexIdByTitle(string title)
        {
            var sportComplex = await _dbContext.SportComplex.FirstOrDefaultAsync(x => x.Title.Equals(title));
            return sportComplex.SportComplexId;
        }

        /// <summary>
        /// Gets list of sport complexes' ids.
        /// </summary>
        /// <returns>List of all existing sport complexes' ids.</returns>
        public virtual async Task<List<string>> GetAllSportComplexesIds()
            => await _dbContext.SportComplex
                .Select(x => x.SportComplexId)
                .ToListAsync();
    }
}