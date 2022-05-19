using System.ComponentModel.DataAnnotations;

namespace C1System.ViewModels;

public class UpdateTechMediaViewModel
{
    public Guid TechnologyId { get; set; }

    public Guid MediaId { get; set; }
    public string FileName { get; set; }
}