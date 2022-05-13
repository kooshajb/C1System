using System.ComponentModel.DataAnnotations;
using System;

namespace C1System;

public class ChatFaq : BaseEntity
{
    [Key] 
    public Guid ChatFaqId { get; set; }
    
    //todo سوال میتواند به صورت متن یا عکس یا فایل باشد 
    [Display(Name = "سوال")]
    [MaxLength(800, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? ChatFaqQuestion { get; set; }
    
    //todo جواب میتواند به صورت متن یا عکس یا فایل باشد 
    [Display(Name = "جواب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string? ChatFaqAnswer { get; set; }
}