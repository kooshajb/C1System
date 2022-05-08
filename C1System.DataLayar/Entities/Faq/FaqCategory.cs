using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.Faq;

public class FaqCategory
{
    [Key] 
    public Guid FaqCategoryId { get; set; }
    
    [Display(Name = "عنوان دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(200, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FaqCategoryTitle { get; set; }
    
    [Display(Name ="تصویر دسته بندی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string FaqCategoryImage { get; set; }
}