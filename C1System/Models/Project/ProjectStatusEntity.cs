using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("ProjectStatus")]
public class ProjectStatusEntity
{
    [Key]
    public Guid ProjectStatusId { get; set; }
    
    [Display(Name ="وضعیت پروژه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    #region Relation

    public List<ProjectEntity> Projects { get; set; }
    
    #endregion
}