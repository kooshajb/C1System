using System.ComponentModel.DataAnnotations;

namespace C1System;

public class UserRole
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
}