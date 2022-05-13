using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace C1System;

public class Category_Product
{
    [Key]
    public Guid CategoryProductId { get; set; }
    public Guid PortfolioId { get; set; }
    public Guid CategoryId { get; set; }

    #region Relation
    
    public Category Category { get; set; }
    public Portfolio Portfolio { get; set; }

    #endregion
}