using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace C1System;

public class Province
{
    [Key]
    [Display(Name = "شناسه")]
    public int ProvinceId { get; set; }
    
    [StringLength(50)]
    [Display(Name = "نام استان")]
    public string ProvinceName { get; set; }
    
    [Display(Name = "کشور")]
    public int CountryId { get; set; }

    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; }

    public virtual ICollection<City> Cities { get; set; }
}