using System.ComponentModel.DataAnnotations;

namespace C1System;

public class TicketStatus
{
    [Key] 
    public int TicketStatusId { get; set; }
    
    [Display(Name = "نام وضعیت تیکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string TicketStatusName { get; set; }
    
    //todo - ticket entity
}