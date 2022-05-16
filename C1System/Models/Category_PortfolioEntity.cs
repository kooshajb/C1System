using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace C1System;

[Table("Category_Portfolio")]
public class Category_PortfolioEntity
{
    [Key]
    public Guid CategoryPortfolioId { get; set; }
    public Guid PortfolioId { get; set; }
    public Guid CategoryId { get; set; }

    #region Relation
    
    [ForeignKey("CategoryId")]
    public CategoryEntity Category { get; set; }
    
    [ForeignKey("PortfolioId")]
    public PortfolioEntity Portfolio { get; set; }

    #endregion
}