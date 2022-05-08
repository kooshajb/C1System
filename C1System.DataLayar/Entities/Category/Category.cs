using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
    
    [Display(Name ="عنوان خدمت")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name = "عنوان فرعی خدمت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(20, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SubTitle { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Description { get; set; }
    
    [Display(Name = "متن معرفی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IntroDescription { get; set; }
    
    [Display(Name = "متن بنر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string BannerDescription { get; set; }
    
    [Display(Name = "تصویر بنر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string BannerImage { get; set; }
    
    [Display(Name = "تصویر آیکن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IconImage { get; set; }
    
    [Display(Name = "تصویر آیکن منو")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IconMenuImage { get; set; }
    
    [Display(Name = "ویدئو معرفی")]
    public string? VideoIntro { get; set; }
}