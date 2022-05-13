using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class FamiliarityWithSivan
{
    [Key]
    public Guid FamiliarityId { get; set; }
    
    [Display(Name ="نحوه آشنایی با سیوان")]
    [Required(ErrorMessage ="لطفا {0} را وارد کنید .")]
    [MinLength(5 , ErrorMessage ="تعداد {0} نباید کمتر از {1} باشد.")]
    [MaxLength(300 , ErrorMessage = "تعداد {0} نباید بیشتر از {1} باشد.")]
    public string Title { get; set; }
}