using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateCategoryMediaViewModel
{
    public Guid CategoryId { get; set; }

    public Guid MediaId { get; set; }
    public string FileName { get; set; }
}