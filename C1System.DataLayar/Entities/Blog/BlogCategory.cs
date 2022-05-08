using System.ComponentModel.DataAnnotations;
using C1System.DataLayar.Entities.Base;

namespace C1System.DataLayar.Entities.Blog;

public class BlogCategory : BaseEntity
{
    [Key]
    public int BlogCategoryId { get; set; }
    
    [Display(Name ="عنوان دسته بندی پست")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
}