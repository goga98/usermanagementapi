using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Interfaces.IRepositories;

namespace UserManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Private Members

        protected readonly UserManagementDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region Constructors

        protected Repository(UserManagementDbContext umDbContext)
        {
            _dbContext = umDbContext ?? throw new ArgumentNullException(nameof(umDbContext));
            _dbSet = _dbContext.Set<T>();
        }

        #endregion

        #region Methods

        public IQueryable<T?> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual IQueryable<T> GetAllIncludeRelatedEntities()
        {
            return _dbSet.AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public IQueryable<T?> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        #endregion
    }
}
