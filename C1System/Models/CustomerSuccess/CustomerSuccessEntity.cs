using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("CustomerSuccess")]
public class CustomerSuccessEntity
{
    [Key] 
    public Guid CustomerSuccessId { get; set; } = Guid.NewGuid();

    [Display(Name = "نام مدیرعامل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(120, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string ManagerName { get; set; }

    [Display(Name = "سمت مدیرعامل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(3, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string ManagerSide { get; set; }

    [Display(Name = "نام شرکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string CompanyName { get; set; }

    [Display(Name = "نام استارتاپ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string StartupName { get; set; }

    [Display(Name = "حوزه فعالیت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string ActivityName { get; set; }

    [Display(Name = "لوگو شرکت")]
    public string? CompanyLogo { get; set; }

    [Display(Name = "سخن مدیر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string ManagerSpeech { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Description { get; set; }

    [Display(Name = "فایل ویدئو")]
    public string? VideoFile { get; set; }

    [Display(Name = "عکس کاور ویدئو")]
    public string? CoverVideoImage { get; set; }

    [Display(Name = "عنوان ویدئو")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? VideoTitle { get; set; }

    [Display(Name = "زیرعنوان ویدئو")]
    [MinLength(5, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string? VideoSubTitle { get; set; }
    //
    // [Display(Name = "گالری تصاویر")]
    // public string Media { get; set; }
}