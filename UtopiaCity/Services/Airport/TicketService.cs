using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Airport;
using UtopiaCity.Models.TimelineModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Services.Airport
{
    public class TicketService
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Ticket> GetTicketsComplex()
        {
            var ticket = _dbContext.Tickets.Include(t => t.Flight).Include(t => t.PermitedModel).Include(t => t.ResidentAccount);
            return ticket.ToList();
        }

        public Ticket GetTicketComplexById(string id)
        {
            var ticket = _dbContext.Tickets
                                           .Include(t => t.Flight)
                                           .Include(t => t.PermitedModel)
                                           .Include(t => t.ResidentAccount)
                                           .FirstOrDefault(m => m.Id == id);
            return ticket;
        }

        public void AddTickets(Ticket newTicket)
        {
            _dbContext.Add(newTicket);
            _dbContext.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();
        }

        public Ticket FindTicketById(string id)
        {
            return _dbContext.Tickets.Find(id);
        }

        public SelectList GetSelectListOfContextFlights(string dataValueField, string dataTextField)
        {
            var list = new SelectList(_dbContext.Flights, dataValueField, dataTextField);
            return list;
        }
        public SelectList GetSelectListOfContextResidents(string dataValueField, string dataTextField)
        {
            var list = new SelectList(_dbContext.ResidentAccount, dataValueField, dataTextField);
            return list;
        }
        public SelectList GetSelectListOfContextPermissions(string dataValueField, string dataTextField)
        {
            var list = new SelectList(_dbContext.PermitedModel, dataValueField, dataTextField);
            return list;
        }
    }
}
