using System.ComponentModel.DataAnnotations;

namespace C1System.DataLayar.Entities;

public class Gender
{
    [Key]
    public int GenderId { get; set; }

    [Display(Name ="جنسیت")]
    public string GenderName { get; set; }

    #region Relation
    public ICollection<User> Users { get; set; }
    #endregion
}