using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("NewsLetter")]
public class NewsLetterEntity
{
    [Key] 
    public Guid NewsLetterId { get; set; }
    
    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(250, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FullName { get; set; }
    
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(500, ErrorMessage = "لطفا {0} را وارد کنید.")]
    [EmailAddress(ErrorMessage = "لطفا {0} معتبر وارد کنید.")]
    public string Email { get; set; }
}