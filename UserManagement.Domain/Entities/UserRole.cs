using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    [Table("user_role")]
    public class UserRole
    {
        [Column("user_role_id")][Key] public int UserRoleID { get; set; }
        [Column("role")] public string? Role { get; set; }
        [ForeignKey("user_id")] public User? User { get; set; }
    }
}
