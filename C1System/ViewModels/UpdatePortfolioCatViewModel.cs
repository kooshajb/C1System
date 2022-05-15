using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdatePortfolioCatViewModel
{
    public Guid PortfolioId { get; set; }

    [Display(Name = "عنوان نمونه کار")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string PortfolioTitle { get; set; }

    public Guid CategoryPortfolioId { get; set; }
    public Guid CategoryId { get; set; }
}