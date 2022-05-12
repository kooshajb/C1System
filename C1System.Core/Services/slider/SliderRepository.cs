using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.slider
{
    public interface ISliderService
    {
        //List<Slider> GetAllSlider();
        //Slider GetSliderById(Guid id);
        //bool AddSlider(Slider slider);
        //bool DeleteSlider(Slider slider);
        //bool UpdateSlider(Slider slider);
    }

    public class SliderService : ISliderService
    {
        //private readonly C1SystemContext _context;
        //public SliderService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddSlider(Slider slider)
        //{
        //    try
        //    {
        //        _context.Sliders.Add(slider);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeleteSlider(Slider slider)
        //{
        //    if (slider != null)
        //    {
        //        try
        //        {
        //            _context.Sliders.Remove(slider);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //    else
        //        return false;

        //}

        //public List<Slider> GetAllSlider()
        //{
        //    return _context.Sliders.OrderBy(x => x.SliderId).ToList();
        //}

        //public Slider GetSliderById(Guid id)
        //{
        //    return _context.Sliders.Find(id);
        //}

        //public bool UpdateSlider(Slider slider)
        //{
        //    if (slider != null)
        //    {
        //        try
        //        {
        //            _context.Sliders.Update(slider);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    else
        //        return false;
        //}
    }
}
