using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("ProjectDoc")]
public class ProjectDocEntity
{
    [Key]
    public Guid ProjectDocId { get; set; }
    
    [Display(Name ="عنوان فایل مستند")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(100 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    #region Relation
        
    

    #endregion
}