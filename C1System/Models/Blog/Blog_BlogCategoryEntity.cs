using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Blog_BlogCategory")]
public class Blog_BlogCategoryEntity
{
    [Key]
    public Guid BlogBlogCategoryId { get; set; }
    
    public Guid BlogId { get; set; }
    public Guid BlogCategoryId { get; set; }

    #region Relation
    
    [ForeignKey("BlogId")]
    public BlogEntity Blog { get; set; }
    
    [ForeignKey("BlogCategoryId")]
    public BlogCategoryEntity BlogCategory { get; set; }

    #endregion
}