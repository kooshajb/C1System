using System.ComponentModel.DataAnnotations;
using System;

namespace C1System;

public class TypeOfActivityEntity
{
    [Key]
    public Guid TypeOfActivityId { get; set; }
    
    [Display(Name ="نوع فعالیت شما")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
}