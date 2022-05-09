using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Faq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.faq
{
    public interface IFaqService
    {
        List<Faq> GetAllFaq();
        Faq GetFaqById(Guid id);
        bool AddFaq(Faq faq);
        bool DeleteFaq(Faq faq);
        bool UpdateFaq(Faq faq);
    }
    public class FaqService : IFaqService
    {
        private readonly C1SystemContext _context;
        public FaqService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddFaq(Faq faq)
        {
            try
            {
                _context.Faqs.Add(faq);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteFaq(Faq faq)
        {
            if (faq != null)
            {
                try
                {
                    _context.Faqs.Remove(faq);
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

        public List<Faq> GetAllFaq()
        {
            return _context.Faqs.ToList();
        }

        public Faq GetFaqById(Guid id)
        {
            return _context.Faqs.Find(id);
        }

        public bool UpdateFaq(Faq faq)
        {
            if (faq != null)
            {
                try
                {
                    _context.Faqs.Update(faq);
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
