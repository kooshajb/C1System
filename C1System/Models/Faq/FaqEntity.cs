using System.ComponentModel.DataAnnotations;
using System;

namespace C1System;

public class FaqEntity : BannerEntity
{
    [Key] 
    public Guid FaqId { get; set; }
    
    [Display(Name = "سوال")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(600, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string FaqTitle { get; set; }
    
    [Display(Name = "جواب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FaqAnswer { get; set; }

    //todo ارتباط با جدول FaqCategory
}