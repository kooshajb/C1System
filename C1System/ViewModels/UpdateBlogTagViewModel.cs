using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateBlogTagViewModel
{
    public Guid BlogId { get; set; }

    [Display(Name = "عنوان پست")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string BlogTitle { get; set; }

    public Guid TagBlogId { get; set; }
    public Guid TagId { get; set; }
}