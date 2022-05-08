using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.Blog;

public class Blog
{
    [Key]
    public Guid BlogId { get; set; }
    
    [Display(Name ="عنوان پست")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Description { get; set; }
    
    [Display(Name ="متن چکیده")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Lid { get; set; }
    
    [Display(Name ="زمان مطالعه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MaxLength(5 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string StudyTime { get; set; }
    
    [Display(Name ="تصویر شاخص")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string FeatureImage { get; set; }
    
    [Display(Name ="علاقه مندی")]
    public bool? IsLike { get; set; }
    
    [Display(Name ="تگ محبوب")]
    public bool? IsTopTag { get; set; }

    [Display(Name ="برگزیده")]
    public bool? IsSelected { get; set; }
    
    [Display(Name ="امتیازدهی")]
    public int? Point { get; set; }
    
    //todo دکمه اشتراگ گذاری
    //todo برچسب ها
    //todo bookmark
}