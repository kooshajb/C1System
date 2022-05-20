using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateCustomerSuccessMediaViewModel
{
    public Guid CustomerSuccessId { get; set; }
    public Guid MediaId { get; set; }
    public string FileName { get; set; }
}