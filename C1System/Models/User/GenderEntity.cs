using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("Gender")]
public class GenderEntity
{
    [Key]
    public int GenderId { get; set; }

    [Display(Name ="جنسیت")]
    public string GenderName { get; set; }

    #region Relation
    public ICollection<UserEntity> Users { get; set; }
    #endregion
}