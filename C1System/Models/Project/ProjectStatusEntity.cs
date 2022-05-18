using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("ProjectStatus")]
public class ProjectStatusEntity
{
    [Key]
    public Guid ProjectStatusId { get; set; }
    
    
}