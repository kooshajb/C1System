using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "تصویر")]
    public string Picture { get; set; }
    
    [Display(Name ="عنوان خدمت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name = "عنوان فرعی خدمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(80, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SubTitle { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Desc { get; set; }
    
    [Display(Name = "متن معرفی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string IntroDesc { get; set; }

    public bool IsDelete { get; set; }
}