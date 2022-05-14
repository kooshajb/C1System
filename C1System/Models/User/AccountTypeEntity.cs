using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table("AccountType")]
public class AccountTypeEntity
{
    [Key]
    public int AccountTypeId { get; set; }

    [Display(Name ="نوع کاربری")]
    public string AccountTypeName { get; set; }
    
    #region Relation
    // public ICollection<User> Users { get; set; }
    #endregion
}