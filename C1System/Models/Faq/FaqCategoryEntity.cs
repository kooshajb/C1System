using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("FaqCategory")]
public class FaqCategoryEntity
{
    [Key] 
    public Guid FaqCategoryId { get; set; }
    
    [Display(Name = "عنوان دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string FaqCategoryTitle { get; set; }
    
    [Display(Name ="تصویر دسته بندی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string FaqCategoryImage { get; set; }
}