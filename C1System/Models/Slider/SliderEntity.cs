using System;
using System.ComponentModel.DataAnnotations;

namespace C1System;
public class SliderEntity
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

    [Display(Name = "تصویر اسلاید")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string SlideImage { get; set; }
    
    [Display(Name = "توضیحات")]
    [MinLength(3, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(200, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Description { get; set; }
    
    [Display(Name = "ترتیب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string SliderSort { get; set; }
}
