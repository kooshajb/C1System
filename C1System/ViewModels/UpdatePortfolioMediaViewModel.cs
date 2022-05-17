using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdatePortfolioMediaViewModel
{
    public Guid PortfolioId { get; set; }
    public string FileName { get; set; }
}