using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace C1System;

public class Category_Portfolio
{
    [Key]
    public Guid CategoryPortfolioId { get; set; }
    public Guid PortfolioId { get; set; }
    public Guid CategoryId { get; set; }

    #region Relation
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
    
    [ForeignKey("PortfolioId")]
    public Portfolio Portfolio { get; set; }

    #endregion
}