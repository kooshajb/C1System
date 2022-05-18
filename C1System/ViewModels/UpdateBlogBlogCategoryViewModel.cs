using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateBlogBlogCategoryViewModel
{
    public Guid BlogId { get; set; }

    [Display(Name = "عنوان پست")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string BlogTitle { get; set; }

    public Guid BlogBlogCategoryId { get; set; }
    
    public Guid BlogCategoryId { get; set; }
}