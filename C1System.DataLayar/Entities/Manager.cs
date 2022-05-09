using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Manager
{  
    [Key]
    public Guid ManagerId { get; set; }
    
    [Display(Name ="نام مدیرعامل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید.")]
    [MinLength(10 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(80 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name ="سمت مدیرعامل")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Side { get; set; }

    [Display(Name = "متن معرفی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Description { get; set; }
    
    [Display(Name = "فایل ویدئو")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string VideoFile { get; set; }
    
    [Display(Name = "عکس کاور ویدئو")]
    public string? CoverVideoImage { get; set; }
    
    [Display(Name ="لینک واتس اپ")]
    public string? WhatsAppLink { get; set; }
    
    [Display(Name ="لینک اینستاگرام")]
    public string? InstagramLink { get; set; }
    
    [Display(Name ="لینک لینکدین")]
    public string? LinkedinLink { get; set; }
}