using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace C1System;

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