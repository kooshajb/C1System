using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Country")]
public class CountryEntity
{
    [Key]
    [Display(Name = "شناسه")]
    public int CountryId { get; set; }
    
    [StringLength(200)]
    [Display(Name = "نام کشور")]
    public string CountryName { get; set; }
}