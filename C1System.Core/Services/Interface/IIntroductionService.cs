using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface IIntroductionService
    {
        List<Introduction> GetAllIntroduction();
        Introduction GetIntroductionById(Guid id);
        bool AddIntroduction(Introduction introduction);
        bool DeleteIntroduction(Introduction introduction);
        bool UpdateIntroduction(Introduction introduction);
    }
}
