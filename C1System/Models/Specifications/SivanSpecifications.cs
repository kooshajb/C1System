using System.ComponentModel.DataAnnotations;
using System;

namespace C1System;

public class SivanSpecifications
{
    [Key]
    public Guid Id { get; set; }
    
    [Display(Name ="عنوان")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(200 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SivanTitle { get; set; }
    
    [Display(Name ="زیرعنوان")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SivanSubTitle { get; set; }
    
    [Display(Name ="لوگو سیوان")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string SivanLogo { get; set; }

    [Display(Name ="توضیحات فوتر")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string SivanFooterDesc { get; set; }
    
    [Display(Name ="متن قوانین و مقررات")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string SivanRules { get; set; }

    [Display(Name ="ایمیل اصلی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [EmailAddress(ErrorMessage = "لطفا {0} معتبر وارد کنید")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Email { get; set; }
    
    [Display(Name ="لینک فیس بوک")]
    public string? SivanFaceBookLink { get; set; }
    
    [Display(Name ="لینک لینکدین")]
    public string? SivanLinkedinLink { get; set; }
    
    [Display(Name ="لینک اینستاگرام")]
    public string? SivanInstagramLink { get; set; }
    
    [Display(Name ="لینک واتس اپ")]
    public string? SivanWhatsAppLink { get; set; }
    
    //todo ارتباط با جدول شعبه ها
}