using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("ProjectType")]

public class ProjectTypeEntity
{
    [Key]
    public Guid ProjectTypeId { get; set; }
    
    [Display(Name ="نوع پروژه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    #region Relation
    public List<Project_ProjectTypeEntity> ProjectProjectTypes { get; set; }
    
    #endregion
}