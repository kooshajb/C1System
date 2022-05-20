using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateBlogMediaViewModel
{
    public Guid BlogId { get; set; }

    public Guid MediaId { get; set; }
    public string FileName { get; set; }
}