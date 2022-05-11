using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class SymbolsOfTrust
{
    [Key]
    public Guid SymbolsOfTrustId { get; set; }
    
    [Display(Name ="عنوان نماد اعتماد")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(200 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SymbolsOfTrustTitle { get; set; }
    
    [Display(Name ="لوگو نماد اعتماد")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string SymbolsOfTrustLogo { get; set; }
    
    [Display(Name ="لینک نماد اعتماد")]
    [MinLength(150 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    public string? SymbolsOfTrustLink { get; set; }
}