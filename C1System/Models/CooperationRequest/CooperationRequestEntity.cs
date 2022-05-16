using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("CooperationRequest")]
public class CooperationRequestEntity
{
    [Key]
    public int CooperationRequestId { get; set; }
    
    [Display(Name ="نام و نام خانوادگی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(8 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string FullName { get; set; }
    
    [Display(Name ="شماره موبایل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [Phone(ErrorMessage = "لطفا {0} معتبر وارد کنید")]
    [MinLength(11 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(11 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string PhoneNumber { get; set; }
    
    [Display(Name ="ایمیل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [EmailAddress(ErrorMessage = "لطفا {0} معتبر وارد کنید")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Email { get; set; }
    
    [Display(Name = "متن پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Description { get; set; }
    
    [Display(Name = "فایل رزومه")]
    public string? CVFile { get; set; }
}