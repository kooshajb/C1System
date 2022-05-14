using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System;

[Table(" UserRole")]
public class UserRoleEntity
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
}