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
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(UserManagementDbContext context) : base(context)
        {
        }

        public async Task<UserProfile?> GetUserWithProfile(int userProfileId)
        {
            return _dbContext.Set<UserProfile>().Include(x => x.User)
                .FirstOrDefault(x => x.UserProfileId == userProfileId);
        }
    }
}
