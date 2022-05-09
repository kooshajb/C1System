using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.ticket
{
    public interface ITicketService
    {
        List<Ticket> GetAllTicket();
        Ticket GetTicketById(Guid id);
        bool AddTicket(Ticket ticket);
        bool DeleteTicket(Ticket ticket);
        bool UpdateTicket(Ticket ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly C1SystemContext _context;
        public TicketService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddTicket(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                try
                {
                    _context.Tickets.Remove(ticket);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
                return false;
        }

        public List<Ticket> GetAllTicket()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetTicketById(Guid id)
        {
            return _context.Tickets.Find(id);
        }

        public bool UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                try
                {
                    _context.Tickets.Update(ticket);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
                return false;
        }
    }
}
