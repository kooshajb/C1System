using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System.DataLayar.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    
    [Display(Name ="نام و نام خانوادگی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name ="تصویر پروفایل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string ProfilePic { get; set; }
    
    [Display(Name ="تصویر کاور پروفایل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string CoverProfilePic { get; set; }
    
    [Display(Name ="نام کاربری")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(10 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string UserName { get; set; }
    
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
    [MaxLength(1500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Email { get; set; }
    
    [Display(Name ="آدرس پروفایل")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(800 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string ProfileAddress { get; set; }
    
    public virtual Gender Gender { get; set; }

    [Display(Name ="تاریخ تولد")]
    public DataType? BirthDate { get; set; }
    
    [Display(Name ="بیوگرافی")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string? Biography { get; set; }
    
    public virtual AccountType AccountType { get; set; }
}