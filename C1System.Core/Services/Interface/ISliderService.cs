using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface ISliderService
    {
        List<Slider> GetAllSlider();
        Slider GetSliderById(Guid id);
        bool AddSlider(Slider slider);
        bool DeleteSlider(Slider slider);
        bool UpdateSlider(Slider slider);
    }
}
