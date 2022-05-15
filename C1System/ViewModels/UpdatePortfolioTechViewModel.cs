using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdatePortfolioTechViewModel
{
    public Guid PortfolioId { get; set; }

    [Display(Name = "عنوان نمونه کار")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string PortfolioTitle { get; set; }

    public Guid TechnologyPortfolioId { get; set; }
    public Guid TechnologyId { get; set; }
}