using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.NewsLetter;

public class NewsLetter
{
    [Key] 
    public Guid NewsLetterId { get; set; }
    
    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(250, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FullName { get; set; }
    
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    [EmailAddress(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
    public string Email { get; set; }
}