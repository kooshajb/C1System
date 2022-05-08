using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class CategoryPackage
{
    [Key]
    public Guid CategoryId { get; set; }
    
    [Display(Name ="نام پکیج")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(80 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name = "زیرعنوان پکیج")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SubTitle { get; set; }
    
    //todo ارتباط با لیست اتم ها اضافه شود 
}