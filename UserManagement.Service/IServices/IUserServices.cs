using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Shared.Models.UserDtos;

namespace UserManagement.Service.IServices
{
    public interface IUserServices
    {
        Task InsertUser(InsertDto model);
        Task UpdateUser(UpdateUser model);
        bool IsExist(LoginDto model);
        Task InitializeRoles(UserManager<UserDto> userManager, RoleManager<IdentityRole> roleManager);
    }
}
