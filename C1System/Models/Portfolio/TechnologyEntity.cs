using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C1System.Media;

namespace C1System;

[Table("Technology")]
public class TechnologyEntity
{
    [Key]
    public Guid TechnologyId { get; set; }
    
    [Display(Name ="نام تکنولوژی")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(250 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
    
    #region Relation

    public List<Technology_PortfolioEntity> TechnologyPortfolios { get; set; }
    public List<MediaEntity> IconTechnology { get; set; }

    #endregion
}