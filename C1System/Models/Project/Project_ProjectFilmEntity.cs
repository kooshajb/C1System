using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Project_ProjectFilm")]
public class Project_ProjectFilmEntity
{
    [Key]
    public Guid ProjectProjectFilmId { get; set; }
    
    public Guid ProjectId { get; set; }
    public Guid ProjectFilmId { get; set; }
    
    #region Relation
    
    [ForeignKey("ProjectId")]
    public ProjectEntity Project { get; set; }
    
    [ForeignKey("ProjectFilmId")]
    public ProjectFilmEntity ProjectFilm { get; set; }

    #endregion
}