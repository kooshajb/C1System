using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class CustomerSpeech
{
    [Key]
    public Guid CustomerSpeechId { get; set; }
    
    [Display(Name ="نام مشتری")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string CustomerName { get; set; }

    [Display(Name = "سمت مشتری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string CustomerSide { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Desc { get; set; }
    
    [Display(Name = "تصویر مشتری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Avatar { get; set; }
}