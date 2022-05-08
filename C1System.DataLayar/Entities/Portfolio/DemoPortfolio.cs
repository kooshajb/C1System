using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class DemoPortfolio
{
    [Key]
    public Guid DemoPortfolioId { get; set; }
    
    [Display(Name ="عنوان دمو")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    public string Desc { get; set; }
    
    [Display(Name = "ویدئو")]
    public string Video { get; set; }
    
    [Display(Name = "عکس کاور ویدئو")]
    public string CoverVideo { get; set; }
}