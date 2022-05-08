using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.CareerOpportunity;

public class CareerOpportunity
{
    [Key] 
    public Guid CareerOpportunityId { get; set; }
    
    [Display(Name = "عنوان فرصت شغلی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Title { get; set; }
    
    [Display(Name = "تصویر شاخص")]
    public string FeatureMedia { get; set; }
    
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید .")]
    [MinLength(200, ErrorMessage = "تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(1500, ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Description { get; set; }
}