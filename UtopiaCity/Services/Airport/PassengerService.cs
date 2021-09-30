using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.CityAdministration;

namespace UtopiaCity.Services.Airport
{
    public class PassengerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public PassengerService(ApplicationDbContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<Passenger> GetListOfPassengers()
        {
            return _dbContext.Passengers.Include(x => x.Ticket).Include(x=>x.ResidentAccount).ToList();
        }

        public List<ArrivingPassenger> GetArrivingPassengers()
        {
            return _dbContext.ArrivingPassengers.ToList();
        }

        public Passenger GetPassengerById(string id)
        {
            return _dbContext.Passengers.Include(x => x.Ticket).Include(x=>x.ResidentAccount).FirstOrDefault(x => x.Id.Equals(id));
        }

        public ArrivingPassenger GetArrivingPassengerById(string id)
        {
            return _dbContext.ArrivingPassengers.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void AddPassenger(Passenger newPassenger)
        {
            _dbContext.Add(newPassenger);
            _dbContext.SaveChanges();
        }

        public void AddArrivingPassenger(ArrivingPassenger passenger)
        {
            _dbContext.Add(passenger);
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

        public void DeleteArrivingPassenger(ArrivingPassenger passenger)
        {
            _dbContext.Remove(passenger);
            _dbContext.SaveChanges();
        }

        public ResidentAccount GetNewResidentFromArrivedPassegers(ArrivingPassenger passenger)
        {
            var resident = _mapper.Map<ResidentAccount>(passenger);

            return resident;
        }
    }
}
