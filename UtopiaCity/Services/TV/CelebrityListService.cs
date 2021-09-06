using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TV;

namespace UtopiaCity.Services.TV
{
    public class CelebrityListService
    {
        private ApplicationDbContext _dbContext;

        public CelebrityListService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CelebrityList GetTvShowById(string Id)
        {
            return _dbContext.CelebrityList.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public List<CelebrityList> GetListOfTvShows()
        {
            return _dbContext.CelebrityList.ToList();
        }

        public void UpdateCelebrity(CelebrityList CelebrityList)
        {
            _dbContext.Update(CelebrityList);
            _dbContext.SaveChanges();
        }

        public void AddCelebrity(CelebrityList CelebrityList)
        {
            _dbContext.Add(CelebrityList);
            _dbContext.SaveChanges();
        }

        public void DeleteCelebrity(CelebrityList CelebrityList)
        {
            _dbContext.Remove(CelebrityList);
            _dbContext.SaveChanges();
        }
    }
}
