using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.Faq;

public class Faq
{
    [Key] 
    public Guid FaqId { get; set; }
    
    [Display(Name = "سوال")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(200, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FaqTitle { get; set; }
    
    [Display(Name = "جواب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(200, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FaqAnswer { get; set; }
    
    [Display(Name ="تصویر دسته بندی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string FaqImage { get; set; }
    
    //todo ارتباط با جدول FaqCategory
}