using System.ComponentModel.DataAnnotations;

namespace C1System;

public class UserRoleEntity
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
}