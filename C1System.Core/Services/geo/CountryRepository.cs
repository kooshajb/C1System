using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.geo
{
    public interface ICountryService
    {
        List<Country> GetAllCountry();
        Country GetCountryById(Guid id);
        bool AddCountry(Country country);
        bool DeleteCountry(Country country);
        bool UpdateCountry(Country country);
    }

    public class CountryService : ICountryService
    {
        private readonly C1SystemContext _context;
        public CountryService(C1SystemContext context)
        {
            _context = context;
        }


        public bool AddCountry(Country country)
        {
            try
            {
                _context.Countries.Add(country);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCountry(Country country)
        {
            if (country != null)
            {
                try
                {
                    _context.Countries.Remove(country);
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

        public List<Country> GetAllCountry()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(Guid id)
        {
            return _context.Countries.Find(id);
        }

        public bool UpdateCountry(Country country)
        {
            if (country != null)
            {
                try
                {
                    _context.Countries.Update(country);
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
