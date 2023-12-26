using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserManagement.Domain.Entities;
using UserManagement.Shared.Models.UserDtos;

namespace UserManagement.Infrastructure
{
    public class UserManagementDbContext:IdentityDbContext<UserDto>
    {
        #region Constructors

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
        }

        #endregion

        #region Tables

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<UserRole>? UserRoles { get; set; }

        #endregion
    }
}
