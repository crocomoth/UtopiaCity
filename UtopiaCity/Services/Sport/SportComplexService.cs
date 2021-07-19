using System.Collections.Generic;
using System.Linq;
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
        public List<SportComplex> GetAllSportComplexes() => _dbContext.SportComplex.ToList();

        /// <summary>
        /// Gets <see cref="SportComplex"/> by Id.
        /// </summary>
        /// <param name="id">Id of sport complex.</param>
        /// <returns>Sport complex if it exists, otherwise null.</returns>
        public SportComplex GetSportComplexById(string id) => _dbContext.SportComplex.FirstOrDefault(x => x.SportComplexId.Equals(id));

        /// <summary>
        /// Method for adding new sport complex to database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for adding.</param>
        public void AddSportComplexToDb(SportComplex sportComplex)
        {
            _dbContext.Add(sportComplex);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for removing sport complex from database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for adding.</param>
        public void RemoveSportComplexFromDb(SportComplex sportComplex)
        {
            _dbContext.Remove(sportComplex);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Method for updating sport complex in database.
        /// </summary>
        /// <param name="sportComplex">Sport complex for adding.</param>
        public void UpdateSportComplexInDb(SportComplex sportComplex)
        {
            _dbContext.SportComplex.Update(sportComplex);
            _dbContext.SaveChanges();
        }
    }
}