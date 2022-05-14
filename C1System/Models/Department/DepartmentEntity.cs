using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Department")]
public class DepartmentEntity
{
    [Key] 
    public int DepartmentId { get; set; }
    
    [Display(Name = "نام دپارتمان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string DepartmentName { get; set; }
    
    [Display(Name = "متن معرفی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(500, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string DepartmentIntro { get; set; }
}