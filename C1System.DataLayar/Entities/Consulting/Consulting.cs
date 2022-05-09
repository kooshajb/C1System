using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Consulting
{
    [Key] 
    public Guid ConsultingId { get; set; }
    
    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(200, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FullName { get; set; }
    
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(11, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(11, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string MobileNumber { get; set; }
}