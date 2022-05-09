using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.CareerOpportunity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.careerOpportunity
{
    public interface ICareerOpportunityService
    {
        List<CareerOpportunity> GetAllCareerOpportunity();
        CareerOpportunity GetCareerOpportunityById(Guid id);
        bool AddCareerOpportunity(CareerOpportunity careerOpportunity);
        bool DeleteCareerOpportunity(CareerOpportunity careerOpportunity);
        bool UpdateCareerOpportunity(CareerOpportunity careerOpportunity);
    }
    public class CareerOpportunityService : ICareerOpportunityService
    {
        private readonly C1SystemContext _context;
        public CareerOpportunityService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddCareerOpportunity(CareerOpportunity careerOpportunity)
        {
            try
            {
                _context.CareerOpportunities.Add(careerOpportunity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCareerOpportunity(CareerOpportunity careerOpportunity)
        {
            if (careerOpportunity != null)
            {
                try
                {
                    _context.CareerOpportunities.Remove(careerOpportunity);
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

        public List<CareerOpportunity> GetAllCareerOpportunity()
        {
            return _context.CareerOpportunities.ToList();
        }

        public CareerOpportunity GetCareerOpportunityById(Guid id)
        {
            return _context.CareerOpportunities.Find(id);
        }

        public bool UpdateCareerOpportunity(CareerOpportunity careerOpportunity)
        {
            if (careerOpportunity != null)
            {
                try
                {
                    _context.CareerOpportunities.Update(careerOpportunity);
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
