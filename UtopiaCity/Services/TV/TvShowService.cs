using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.TV;

namespace UtopiaCity.Services.TV
{
    public class TvShowService
    {
        private ApplicationDbContext _dbContext;

        public TvShowService(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public TvShow GetTvShowById(string Id) 
        {
            return _dbContext.TvShows.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public List<TvShow> GetListOfTvShows() 
        {
            return _dbContext.TvShows.ToList();
        }

        public void UpdateTvShow(TvShow TvShow)
        {
            _dbContext.Update(TvShow);
            _dbContext.SaveChanges();
        }

        public void AddTvShow(TvShow TvShow)
        {
            _dbContext.Add(TvShow);
            _dbContext.SaveChanges();
        }

        public void DeleteTvShow(TvShow TvShow)
        {
            _dbContext.Remove(TvShow);
            _dbContext.SaveChanges();
        }
    }
}
