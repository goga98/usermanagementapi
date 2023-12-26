using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.IRepositories;

namespace UserManagement.Infrastructure.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(UserManagementDbContext context) : base(context)
        {
        }

        public async Task<UserRole?> GetUserWithProfile(int userRoleId)
        {
            return _dbContext.Set<UserRole>().Include(x => x.User)
                .FirstOrDefault(x => x.UserRoleID == userRoleId);
        }
    }
}
