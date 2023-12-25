using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    [Table("users")]
    public class User
    {
        #region Properties

        [Column("user_id")][Key] public int UserId { get; set; }
        [Column("username")] public string? Username { get; set; }
        [Column("password")] public string? Password { get; set; }

        #endregion
    }
}
