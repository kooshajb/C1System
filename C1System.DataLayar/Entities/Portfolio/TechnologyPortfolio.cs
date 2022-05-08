using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class TechnologyPortfolio
{
    [Key]
    public int TechnologyPortfolioId { get; set; }
    
    [Display(Name ="نام تکنولوژی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name = "تصویر تکنولوژی")]
    public string TechnologyImage { get; set; }
}