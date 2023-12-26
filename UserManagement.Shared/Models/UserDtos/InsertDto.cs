using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared.Models.UserDtos
{
    public class InsertDto
    {
        public InsertUserDto? User { get; set; }
        public UserRoles? UserRoles { get; set; }
    }
}
