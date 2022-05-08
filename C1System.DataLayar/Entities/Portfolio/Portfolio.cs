using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class Portfolio
{
    [Key]
    public Guid PortfolioId { get; set; }

    [Display(Name = "تصویر")]
    public string Picture { get; set; }
    
    [Display(Name ="عنوان خدمت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name = "عنوان فرعی خدمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(80, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SubTitle { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Description { get; set; }
    public bool IsDelete { get; set; }

    [Display(Name = "امتیاز")]
    public int Score { get; set; }

    [Display(Name = "آدرس سایت")]
    [Url(ErrorMessage = "{0} معتبر وارد کنید")]
    public string SiteAddress { get; set; }
    
    [Display(Name = "نام شرکت")]
    [MinLength(20, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(200, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string CompanyName { get; set; }

    [Display(Name = "لوگو شرکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string CompanyLogo { get; set; }
    
<<<<<<< Updated upstream
    [Display(Name = "تصاویر")]
    public string Media { get; set; }
=======
    [Display(Name = "تصویر شاخص")]
    public string FeatureMedia { get; set; }
    
    [Display(Name = "تصاویر")]
    public string Media { get; set; }

    [Display(Name ="امتیازدهی")]
    public int? Point { get; set; }
    
    //todo ارتباط با اینیتیت DemoPortfolio اضافه شود 
    //todo ارتباط با TechnologyPortfolio
    //todo ارتباط با برچسب ها
>>>>>>> Stashed changes
}