using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

public class CategoryEntity
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
    
    [Display(Name = "تصویر آیکن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IconImage { get; set; }
    
    [Display(Name = "متن معرفی صفحه داخلی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IntroDescription { get; set; }
    
    [Display(Name = "تصویر معرفی صفحه داخلی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IntroImage { get; set; }

    [Display(Name = "عنوان بنر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(20, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string BannerTitle { get; set; }
    
    [Display(Name = "متن توضیح بنر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string BannerDescription { get; set; }
    
    [Display(Name = "تصویر بنر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string BannerImage { get; set; }
    
    [Display(Name = "تصویر آیکن منو")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string IconMenuImage { get; set; }
    
    [Display(Name = "ویدئو معرفی")]
    public string? VideoIntro { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsDelete { get; set; }
    
    #region Relation
    
    [ForeignKey("ParentId")]
    public CategoryEntity Parent { get; set; }
    
    // public IEnumerable<Category_Product> CategoryProducts { get; set; }

    #endregion
}