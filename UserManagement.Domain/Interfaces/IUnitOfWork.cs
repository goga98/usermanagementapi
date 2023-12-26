using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Interfaces.IRepositories;

namespace UserManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
        IUserRoleRepository UserRoleRepository { get; set; }
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
