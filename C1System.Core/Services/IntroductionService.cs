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
    public class IntroductionService : IIntroductionService
    {
        private readonly C1SystemContext _context;
        public IntroductionService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddIntroduction(Introduction introduction)
        {
            try
            {
                _context.Introductions.Add(introduction);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteIntroduction(Introduction introduction)
        {
            if (introduction != null)
            {
                try
                {
                    _context.Introductions.Remove(introduction);
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

        public List<Introduction> GetAllIntroduction()
        {
            return _context.Introductions.ToList();
        }

        public Introduction GetIntroductionById(Guid id)
        {
            return _context.Introductions.Find(id);
        }

        public bool UpdateIntroduction(Introduction introduction)
        {
            if (introduction != null)
            {
                try
                {
                    _context.Introductions.Update(introduction);
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
