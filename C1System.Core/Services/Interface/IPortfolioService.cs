using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface IPortfolioService
    {
        List<Portfolio> GetAllPortfolio();
        Portfolio GetPortfolioById(Guid id);
        bool AddPortfolio(Portfolio portfolio);
        bool DeletePortfolio(Portfolio portfolio);
        bool UpdatePortfolio(Portfolio portfolio);
    }
}
