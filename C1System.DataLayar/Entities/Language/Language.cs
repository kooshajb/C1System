using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System.DataLayar.Entities.Language;

public class Language
{
    [Key] 
    [Display(Name = "سمبل زبان")]
    [StringLength(5)] 
    public string Symbol { get; set; } = "fa-IR";
    
    [Display(Name = "نام زبان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string LanguageName { get; set; }
}