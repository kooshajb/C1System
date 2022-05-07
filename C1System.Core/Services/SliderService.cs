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
    public class SliderService : ISliderService
    {
        private readonly C1SystemContext _context;
        public SliderService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddSlider(Slider slider)
        {
            try
            {
                _context.sliders.Add(slider);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSlider(Slider slider)
        {
            if (slider != null)
            {
                try
                {
                    _context.sliders.Remove(slider);
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

        public List<Slider> GetAllSlider()
        {
            return _context.sliders.OrderBy(x=> x.SliderSort).ToList();
        }

        public Slider GetSliderById(Guid id)
        {
            return _context.sliders.Find(id);
        }

        public bool UpdateSlider(Slider slider)
        {
            if(slider != null)
            {
                try
                {
                    _context.sliders.Update(slider);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
                return false ;
        }
    }
}
