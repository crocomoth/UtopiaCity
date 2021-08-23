using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;

namespace UtopiaCity.Services.Airport
{
    public class PassengerService
    {
        private readonly ApplicationDbContext _dbContext;
        public PassengerService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Passenger> GetListOfPassengers()
        {
            return _dbContext.Passengers.Include(x => x.Ticket).Include(x=>x.ResidentAccount).ToList();
        }

        public Passenger GetPassengerById(string id)
        {
            return _dbContext.Passengers.Include(x => x.Ticket).Include(x=>x.ResidentAccount).FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddPassenger(Passenger newPassenger)
        {
            _dbContext.Add(newPassenger);
            _dbContext.SaveChanges();
        }

        public void UpdatePassenger (Passenger edited)
        {
            _dbContext.Update(edited);
            _dbContext.SaveChanges();
        }

        public void DeletePassenger(Passenger passenger)
        {
            _dbContext.Remove(passenger);
            _dbContext.SaveChanges();
        }
    }
}
