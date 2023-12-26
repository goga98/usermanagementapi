using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.Models.UserDtos
{
    public class UserDto : IdentityUser
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public UserDto? User { get; set; }
    }
}
