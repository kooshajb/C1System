using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.DataLayar.Entities
{
    public class Slider
    {
        [Key]
        public Guid SliderId { get; set; }

        [Display(Name ="عنوان")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
        [MinLength(10 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
        [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
        public string Title { get; set; }

        [Display(Name = "عنوان فرعی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        [MinLength(10, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
        [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
        public string SubTitle { get; set; }
        
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        public string Description { get; set; }
        
        [Display(Name = "تصویر اسلاید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        public string SlideImage { get; set; }
        [MinLength(3, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
        [MaxLength(200, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
        public String Desc { get; set; }


        [Display(Name = "ترتیب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
        public string SliderSort { get; set; }
    }
}
