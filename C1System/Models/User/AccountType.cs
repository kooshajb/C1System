using System.ComponentModel.DataAnnotations;

namespace C1System;

public class AccountType
{
    [Key]
    public int AccountTypeId { get; set; }

    [Display(Name ="نوع کاربری")]
    public string AccountTypeName { get; set; }
    
    #region Relation
    // public ICollection<User> Users { get; set; }
    #endregion
}