using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.Ticket;

public class Priority
{
    [Key] 
    public int PriorityId { get; set; }
    
    [Display(Name = "عنوان تیکت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(20, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string PriorityTitle { get; set; }
}