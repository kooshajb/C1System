using C1System.Core.Services.Interface;
using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services
{
    public class CustomerSpeechService : ICustomerSpeechService
    {
        private readonly C1SystemContext _context;
        public CustomerSpeechService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddCustomerSpeech(CustomerSpeech customerSpeech)
        {
            try
            {
                _context.CustomerSpeechs.Add(customerSpeech);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCustomerSpeech(CustomerSpeech customerSpeech)
        {
            if (customerSpeech != null)
            {
                try
                {
                    _context.CustomerSpeechs.Remove(customerSpeech);
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

        public List<CustomerSpeech> GetAllCustomerSpeech()
        {
            return _context.CustomerSpeechs.ToList();
        }

        public CustomerSpeech GetCustomerSpeechById(Guid id)
        {
            return _context.CustomerSpeechs.Find(id);
        }

        public bool UpdateCustomerSpeech(CustomerSpeech customerSpeech)
        {
            if (customerSpeech != null)
            {
                try
                {
                    _context.CustomerSpeechs.Update(customerSpeech);
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
