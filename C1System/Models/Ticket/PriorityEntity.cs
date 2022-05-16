using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Priority")]
public class PriorityEntity
{
    [Key] 
    public int PriorityId { get; set; }
    
    [Display(Name = "عنوان تیکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(20, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string PriorityTitle { get; set; }
}