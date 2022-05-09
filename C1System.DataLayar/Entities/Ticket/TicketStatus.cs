using System.ComponentModel.DataAnnotations;
using C1System.DataLayar.Entities.Base.Enums;

//using C1System.DataLayar.Entities.Base.Enums;

namespace C1System.DataLayar.Entities.Ticket;

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