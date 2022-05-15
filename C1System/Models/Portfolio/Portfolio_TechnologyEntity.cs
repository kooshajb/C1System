using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

public class Technology_PortfolioEntity
{
    [Key]
    public Guid TechnologyPortfolioId { get; set; }

    public Guid PortfolioId { get; set; }
    public Guid TechnologyId { get; set; }
    
    [ForeignKey("PortfolioId")]
    public PortfolioEntity Portfolio { get; set; }
    
    [ForeignKey("TechnologyId")]
    public TechnologyEntity Technology { get; set; }
}