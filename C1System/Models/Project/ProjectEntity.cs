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

    [Display(Name = "تصویر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Picture { get; set; }
    
    public bool? IsDelete { get; set; }

    [Display(Name = "درصد پیشرفت پروژه")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(3, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public int Progress { get; set; }
    
    [Display(Name = "باقی مانده تا تحویل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public int RemainingUntil { get; set; }
    
    [Display(Name = "باقی مانده پشتیبانی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public int RemainingSupport { get; set; }
    
    // [Display(Name = "تصاویر")]
    // public string Media { get; set; }
    
    //todo support status

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    //vidoes

    #region Relation
        
    public List<Project_ProjectTypeEntity> ProjectProjectTypes { get; set; }

    
    
    //todo وضعیت پروژه
    //todo نوع پشتیبانی 
    //todo وضعیت پشتیبانی 
    //todo ویدئو ها
    #endregion
    
}