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
    public class PortfolioService : IPortfolioService
    {
        private C1SystemContext _context;
        public PortfolioService(C1SystemContext context)
        {
            _context = context;
        }

        public List<Portfolio> GetAllPortfolio()
        {
            return _context.Portfolios.ToList();
        }

        public Portfolio GetPortfolioById(Guid id)
        {
            return _context.Portfolios.Find(id);
        }

        public bool AddPortfolio(Portfolio portfolio)
        {
            try
            {
                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePortfolio(Portfolio portfolio)
        {
            if (portfolio != null)
            {
                try
                {
                    _context.Portfolios.Remove(portfolio);
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

        public bool UpdatePortfolio(Portfolio portfolio)
        {
            if (portfolio != null)
            {
                try
                {
                    _context.Portfolios.Update(portfolio);
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
