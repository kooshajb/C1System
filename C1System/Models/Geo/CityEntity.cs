using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("City")]
public class CityEntity
{
    [Key]
    [Display(Name = "شناسه")]
    public int CityId { get; set; }
    
    [StringLength(50)]
    [Display(Name = "شهر")]
    public string CityName { get; set; }
    
    [Display(Name = "استان")]
    public int ProvinceId { get; set; }

    [ForeignKey(nameof(ProvinceId))]
    public virtual ProvinceEntity Province { get; set; }
}