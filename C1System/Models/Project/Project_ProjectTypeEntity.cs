using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Project_ProjectType")]
public class Project_ProjectTypeEntity
{
    [Key]
    public Guid ProjectProjectTypeId { get; set; }
    
    public Guid ProjectId { get; set; }
    public Guid ProjectTypeId { get; set; }
    
    #region Relation
    
    [ForeignKey("ProjectId")]
    public ProjectEntity Project { get; set; }
    
    [ForeignKey("ProjectTypeId")]
    public ProjectTypeEntity ProjectType { get; set; }

    #endregion
}