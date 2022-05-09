namespace DefaultNamespace;

public class BranchSpecifications
{
    [Key]
    public Guid BranchId { get; set; }
    
    [Display(Name ="آدرس شعبه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(200 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string BranchAddress { get; set; }
    
    [Display(Name ="تلفن ثابت شعبه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [Phone(ErrorMessage = "{0} معتبر نمی باشد.")]
    [MinLength(11 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(11 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string BranchPhoneNumber { get; set; }
    
    [Display(Name ="شماره موبایل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [Phone(ErrorMessage = "{0} معتبر نمی باشد.")]
    [MinLength(11 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(11 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string BranchMobileNumber { get; set; }
}