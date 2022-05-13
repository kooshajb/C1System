using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C1System.DataLayar.Entities;

public class UserRole
{
    [Key]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
}