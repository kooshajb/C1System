using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.portfolio
{
    public interface ITechnologyPortfolioService
    {
        List<TechnologyPortfolio> GetAllTechnologyPortfolio();
        TechnologyPortfolio GetTechnologyPortfolioById(int id);
        bool AddTechnologyPortfolio(TechnologyPortfolio technologyPortfolio);
        bool DeleteTechnologyPortfolio(TechnologyPortfolio technologyPortfolio);
        bool UpdateTechnologyPortfolio(TechnologyPortfolio technologyPortfolio);
    }

    public class TechnologyPortfolioService : ITechnologyPortfolioService
    {
        private readonly C1SystemContext _context;
        public TechnologyPortfolioService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddTechnologyPortfolio(TechnologyPortfolio technologyPortfolio)
        {
            try
            {
                _context.TechnologyPortfolios.Add(technologyPortfolio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTechnologyPortfolio(TechnologyPortfolio technologyPortfolio)
        {
            if (technologyPortfolio != null)
            {
                try
                {
                    _context.TechnologyPortfolios.Remove(technologyPortfolio);
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

        public List<TechnologyPortfolio> GetAllTechnologyPortfolio()
        {
            return _context.TechnologyPortfolios.ToList();
        }

        public TechnologyPortfolio GetTechnologyPortfolioById(int id)
        {
            return _context.TechnologyPortfolios.Find(id);
        }

        public bool UpdateTechnologyPortfolio(TechnologyPortfolio technologyPortfolio)
        {
            if (technologyPortfolio != null)
            {
                try
                {
                    _context.TechnologyPortfolios.Update(technologyPortfolio);
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
