using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.ticket
{
    public interface IPriorityService
    {
        //List<Priority> GetAllPriority();
        //Priority GetPriorityById(int id);
        //bool AddPriority(Priority priority);
        //bool DeletePriority(Priority priority);
        //bool UpdatePriority(Priority priority);
    }

    public class PriorityService : IPriorityService
    {
        //private readonly C1SystemContext _context;
        //public PriorityService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddPriority(Priority priority)
        //{
        //    try
        //    {
        //        _context.Priorities.Add(priority);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeletePriority(Priority priority)
        //{
        //    if (priority != null)
        //    {
        //        try
        //        {
        //            _context.Priorities.Remove(priority);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //    else
        //        return false;
        //}

        //public List<Priority> GetAllPriority()
        //{
        //    return _context.Priorities.ToList();
        //}

        //public Priority GetPriorityById(int id)
        //{
        //    return _context.Priorities.Find(id);
        //}

        //public bool UpdatePriority(Priority priority)
        //{
        //    if (priority != null)
        //    {
        //        try
        //        {
        //            _context.Priorities.Update(priority);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    else
        //        return false;
        //}
    }
}
