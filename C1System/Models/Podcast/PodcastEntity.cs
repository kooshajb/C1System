using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Podcast")]
public class PodcastEntity :BannerEntity
{
    [Key]
    public Guid PodcastId { get; set; }
    
    [Display(Name ="شماره پادکست")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public int PodcastNumber { get; set; }
    
    [Display(Name ="عنوان پادکست")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(20 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(500 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    [Display(Name ="زمان مطالعه")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(5 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string StudyTime { get; set; }
    
    [Display(Name ="تصویر شاخص")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    public string FeatureImage { get; set; }
    
    [Display(Name = "توضیحات پادکست")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1000, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Description { get; set; }

    [Display(Name = "فایل صوتی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(50, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    public string Audio { get; set; }
    
    [Display(Name ="علاقه مندی")]
    public bool? IsLike { get; set; }
    
    [Display(Name ="تگ محبوب")]
    public bool? IsTopTag { get; set; }
    
    [Display(Name ="برگزیده")]
    public bool? IsSelected { get; set; }
    
    [Display(Name ="امتیازدهی")]
    public int? Point { get; set; }

    #region Relation
    
    public List<Tag_PodcastEntity> TagPodcasts { get; set; }

    #endregion
    // public BookMarkEntity BookMark { get; set; }
}