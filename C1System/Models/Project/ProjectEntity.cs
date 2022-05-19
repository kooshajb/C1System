using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace C1System;

[Table("Project")]
public class ProjectEntity
{
    [Key]
    public Guid ProjectId { get; set; }

    [Display(Name ="عنوان پروژه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(150 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }

    [Display(Name = "عنوان فرعی پروژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(10, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(350, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string SubTitle { get; set; }
    
    [Display(Name = "توضیحات پروژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(10, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Description { get; set; }

    public bool? IsDelete { get; set; }

    [Display(Name = "درصد پیشرفت پروژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(3, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public int Progress { get; set; }
    
    [Display(Name = "باقی مانده تا تحویل")]
    public DateTime RemainingUntil { get; set; }
    
    [Display(Name = "باقی مانده پشتیبانی")]
    public DateTime RemainingSupport { get; set; }
    
    [Display(Name = "تاریخ شروع پروژه")]
    public DateTime? StartDate { get; set; }
    
    [Display(Name = "تاریخ پایان پروژه")]
    public DateTime? EndDate { get; set; }

    [Display(Name = "وضعیت پروژه")]
    public ProjectStatusEnum ProjectStatus { get; set; }
    
    [Display(Name = "وضعیت پشتیبانی")]
    public ProjectSupportStatusEnum ProjectSupportStatus { get; set; }

    [Display(Name = "نوع پشتیبانی")]
    public ProjectSupportTypeEnum ProjectSupportType { get; set; }
    
    [Display(Name = "دسته بندی فیلم")]
    public ProjectVideoCategoryEnum ProjectVideoCategory { get; set; }
    
    #region Relation
        
    public List<Project_ProjectTypeEntity> ProjectProjectTypes { get; set; }
    
    
    #endregion
}