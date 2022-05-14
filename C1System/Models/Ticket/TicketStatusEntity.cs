using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("TicketStatus")]
public class TicketStatusEntity
{
    [Key] 
    public int TicketStatusId { get; set; }
    
    [Display(Name = "نام وضعیت تیکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string TicketStatusName { get; set; }
    
    //todo - ticket entity
}