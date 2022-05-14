using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Chat")]
public class ChatEntity : BaseEntity
{
    [Key] 
    public Guid ChatId { get; set; }
    
    [Display(Name = "شماره چت")]
    public long ChatNumber { get; set; }
    
    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FullName { get; set; }

    [Display(Name = "موضوع")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(500, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string ChatSubject { get; set; }
    
    [Display(Name ="ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [EmailAddress(ErrorMessage = "لطفا {0} معتبر وارد کنید")]
    [MinLength(50 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Email { get; set; }

    [Display(Name = "تصویر پروفایل")]
    public string? ProfilePic { get; set; }
    
    //todo ChatFaq
}