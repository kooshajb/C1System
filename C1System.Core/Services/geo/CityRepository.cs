using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.geo
{
    public interface ICityService
    {
        List<City> GetAllCity();
        City GetCityById(Guid id);
        bool AddCity(City city);
        bool DeleteCity(City city);
        bool UpdateCity(City city);
    }
    public class CityService : ICityService
    {
        private readonly C1SystemContext _context;
        public CityService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddCity(City city)
        {
            try
            {
                _context.Cities.Add(city);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                if (city != null)
                {
                    try
                    {
                        _context.Cities.Remove(city);
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
        }

        public bool DeleteCity(City city)
        {
            if (city != null)
            {
                try
                {
                    _context.Cities.Remove(city);
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

        public List<City> GetAllCity()
        {
            return _context.Cities.ToList();
        }

        public City GetCityById(Guid id)
        {
            return _context.Cities.Find(id);
        }

        public bool UpdateCity(City city)
        {
            if (city != null)
            {
                try
                {
                    _context.Cities.Update(city);
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
