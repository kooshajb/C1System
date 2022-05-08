using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities.Department;

public class DepartmentTicket
{
    [Key] 
    public int DepartmentTicketId { get; set; }
    
    [Display(Name = "نام دپارتمان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(50, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string DepartmentTicketName { get; set; }
    
    [Display(Name = "متن معرفی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [StringLength(500, ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string DepartmentTicketIntro { get; set; }
}