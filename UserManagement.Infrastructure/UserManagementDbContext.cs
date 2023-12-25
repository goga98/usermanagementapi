using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure
{
    public class UserManagementDbContext:DbContext
    {
        #region Constructors

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
        }

        #endregion

        #region Tables

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<UserProfile>? UserProfiles { get; set; }

        #endregion
    }
}
