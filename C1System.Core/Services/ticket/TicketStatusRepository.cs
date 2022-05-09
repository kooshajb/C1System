using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.ticket
{
    public interface ITicketStatusService
    {
        List<TicketStatus> GetAllTicketStatus();
        TicketStatus GetTicketStatusById(int id);
        bool AddTicketStatus(TicketStatus ticketStatus);
        bool DeleteTicketStatus(TicketStatus ticketStatus);
        bool UpdateTicketStatus(TicketStatus ticketStatus);
    }

    public class TicketStatusService : ITicketStatusService
    {
        private readonly C1SystemContext _context;
        public TicketStatusService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddTicketStatus(TicketStatus ticketStatus)
        {
            try
            {
                _context.TicketStatuses.Add(ticketStatus);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTicketStatus(TicketStatus ticketStatus)
        {
            if (ticketStatus != null)
            {
                try
                {
                    _context.TicketStatuses.Remove(ticketStatus);
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

        public List<TicketStatus> GetAllTicketStatus()
        {
            return _context.TicketStatuses.ToList();
        }

        public TicketStatus GetTicketStatusById(int id)
        {
            return _context.TicketStatuses.Find(id);
        }

        public bool UpdateTicketStatus(TicketStatus ticketStatus)
        {
            if (ticketStatus != null)
            {
                try
                {
                    _context.TicketStatuses.Update(ticketStatus);
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
