using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.Models.UserDtos
{
    public class UserProfileDto
    {
        public int UserProfileId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PersonalNumber { get; set; }
        public UserDto? User { get; set; }
    }
}
