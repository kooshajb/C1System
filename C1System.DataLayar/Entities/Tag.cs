using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class Tag
{
    [Key]
    public Guid TagId { get; set; }
    
    [Display(Name ="عنوان تگ")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(30 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name ="لینک تگ")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(150 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string Link { get; set; }
} 