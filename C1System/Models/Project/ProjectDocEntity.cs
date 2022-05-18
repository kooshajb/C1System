using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("ProjectDoc")]
public class ProjectDocEntity
{
    [Key]
    public Guid ProjectDocId { get; set; }
    
    
    
}