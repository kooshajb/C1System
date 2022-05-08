using System.ComponentModel.DataAnnotations;
using C1System.DataLayar.Entities.Base;

namespace C1System.DataLayar.Entities.Ticket;

public class Ticket : BaseEntity
{
    [Key] 
    public Guid TicketId { get; set; }
    
    [Display(Name = "شماره تیکت")]
    public long TicketNumber { get; set; }
    
    [Display(Name = "عنوان تیکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string TicketTitle { get; set; }
    
    [Display(Name = "موضوع")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(300, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Subject { get; set; }
    
    //todo ارتباط با جدول deartmantTicket
    //todo ارتباط با جدول ticketStatus

    //todo فیلد باز شده توسط

    [Display(Name = "باز شده یا نشده")]
    public bool? IsOpen { get; set; }
    
    [Display(Name = "پروژه انتخاب شده یا نه")]
    public bool? IsForProject { get; set; }
    
    //todo ارتباط با لیست پروژه های ان شخص
    //todo ارتباط با Priority
    
    [Display(Name = "متن پیام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string Note { get; set; }
    
    [Display(Name = "فایل های ضمیمه")]
    public string? Files { get; set; }
}