using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces.IRepositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task<UserRole?> GetUserWithProfile(int userRoleId);
    }
}
