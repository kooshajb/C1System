using System.ComponentModel.DataAnnotations;
using C1System.DataLayar.Entities.Base;

namespace C1System.DataLayar.Entities.Message;

public class Message : BaseEntity
{
    [Key] 
    public Guid MessageId { get; set; }
    
    [Display(Name = "عنوان پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string MessageTitle { get; set; }
    
    [Display(Name = "متن پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(500, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string MessageDesc { get; set; }

    [Display(Name = "خوانده شده یا نشده")]
    public bool? IsRead { get; set; }
    
    //todo ارتباط با جدول Department
}