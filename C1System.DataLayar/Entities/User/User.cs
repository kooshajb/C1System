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
    public string FullName { get; set; }

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
    
    //todo ارتباط با جدول Gender
    // public virtual Gender Gender { get; set; }

    [Display(Name ="تاریخ تولد")]
    public DataType? BirthDate { get; set; }
    
    [Display(Name ="بیوگرافی")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string? Biography { get; set; }
    
    public virtual AccountType AccountType { get; set; }
    
    //todo ارتباط با جدول TypeOfActivity
    //todo ارتباط با جدول AccountType

    [Display(Name ="کاربر حقوقی یا حقیقی")]
    public bool? ISLegal { get; set; }
    
    [Display(Name ="نام شرکت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(2 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(20 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string CompanyName { get; set; }
    
    [Display(Name ="شماره اقتصادی شرکت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(2 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(20 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string EconomicalNumber { get; set; }

    [Display(Name ="شماره ثبت شرکت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(2 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(20 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string RegistrationNumber { get; set; }
    
    [Display(Name ="تلفن ثابت شرکت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [Phone(ErrorMessage = "{0} معتبر نمی باشد.")]
    [MinLength(11 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(11 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string CompanyPhoneNumber { get; set; }
    
    [Display(Name ="شناسه ملی شرکت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(2 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(20 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string NationalNumber { get; set; }
    
    //todo ارتباط با کشور   
    //todo ارتباط با استان   
    //todo ارتباط با شهر   
    
    [Display(Name ="لینک وب سایت")]
    [MinLength(10 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? SiteLink { get; set; }

    [Display(Name ="لینک فیس بوک")]
    public string? FaceBookLink { get; set; }
    
    [Display(Name ="لینک لینکدین")]
    public string? LinkedinLink { get; set; }
    
    [Display(Name ="لینک اینستاگرام")]
    public string? InstagramLink { get; set; }
    
    [Display(Name ="آدرس")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? Address { get; set; }
}