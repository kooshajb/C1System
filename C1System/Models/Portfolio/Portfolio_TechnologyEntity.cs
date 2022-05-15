using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

public class Portfolio_TechnologyEntity
{
    public Guid PortfolioTechnologyId { get; set; }

    public Guid PortfolioId { get; set; }
    public Guid TechnologyId { get; set; }
    
    [ForeignKey("PortfolioId")]
    public PortfolioEntity Portfolio { get; set; }
    
    [ForeignKey("TechnologyId")]
    public TechnologyEntity Technology { get; set; }
}