using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Tag_Blog")]
public class Tag_BlogEntity
{
    [Key]
    public Guid TagBlogId { get; set; }

    public Guid TagId { get; set; }
    public Guid BlogId { get; set; }

    [ForeignKey("TagId")]
    public TagEntity Tag { get; set; }
    
    [ForeignKey("BlogId")]
    public BlogEntity Blog { get; set; }
}