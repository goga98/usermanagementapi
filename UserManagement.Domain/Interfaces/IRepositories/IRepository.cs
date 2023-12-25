using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T?> GetAll();
        Task<T?> GetByIdAsync(int id);
        void Update(T entity);
        IQueryable<T> GetAllIncludeRelatedEntities();
        Task InsertAsync(T entity);
        Task Delete(T entity);
        IQueryable<T?> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
