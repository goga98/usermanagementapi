using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.Models.UserDtos
{
    public class UpdateUser
    {
        public int UserProfileId { get; set; }
        public UpdateUserDto? User { get; set; }
        public UpdateUserProfileDto? UserProfile { get; set; }
    }
}
