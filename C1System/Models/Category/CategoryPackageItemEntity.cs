using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("CategoryPackageItem")]
public class CategoryPackageItemEntity
{
    [Key]
    public Guid CategoryPackageItemId { get; set; }
    
    [Display(Name ="عنوان")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(80 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name ="توضیحات عنوان")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(80 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? TitleInfo { get; set; }
    
    [Display(Name = "فعال یا غیرفعال")]
    public bool IsActive { get; set; }
    
    //todo - with CategoryPackage

}