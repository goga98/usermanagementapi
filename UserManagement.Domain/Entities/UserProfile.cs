using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Entities
{
    [Table("user_profile")]
    public class UserProfile
    {
        #region Properies

        [Column("user_profile_id")][Key] public int UserProfileId { get; set; }
        [Column("firstname")] public string? FirstName { get; set; }
        [Column("lastname")] public string? LastName { get; set; }
        [Column("role")] public string? Role { get; set; }

        [Column("personal_number")]
        [MinLength(11), MaxLength(11)]
        public string? PersonalNumber { get; set; }

        [ForeignKey("user_id")] public User? User { get; set; }

        #endregion
    }
}
