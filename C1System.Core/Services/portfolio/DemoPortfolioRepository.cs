using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.portfolio
{
    public interface IDemoPortfolioService
    {
        List<DemoPortfolio> GetAllDemoPortfolio();
        DemoPortfolio GetDemoPortfolioById(Guid id);
        bool AddDemoPortfolio(DemoPortfolio demoPortfolio);
        bool DeleteDemoPortfolio(DemoPortfolio demoPortfolio);
        bool UpdateDemoPortfolio(DemoPortfolio demoPortfolio);
    }

    public class DemoPortfolioService : IDemoPortfolioService
    {
        private readonly C1SystemContext _context;
        public DemoPortfolioService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddDemoPortfolio(DemoPortfolio demoPortfolio)
        {
            try
            {
                _context.DemoPortfolios.Add(demoPortfolio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteDemoPortfolio(DemoPortfolio demoPortfolio)
        {
            if (demoPortfolio != null)
            {
                try
                {
                    _context.DemoPortfolios.Remove(demoPortfolio);
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

        public List<DemoPortfolio> GetAllDemoPortfolio()
        {
            return _context.DemoPortfolios.ToList();
        }

        public DemoPortfolio GetDemoPortfolioById(Guid id)
        {
            return _context.DemoPortfolios.Find(id);
        }

        public bool UpdateDemoPortfolio(DemoPortfolio demoPortfolio)
        {
            if (demoPortfolio != null)
            {
                try
                {
                    _context.DemoPortfolios.Update(demoPortfolio);
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
