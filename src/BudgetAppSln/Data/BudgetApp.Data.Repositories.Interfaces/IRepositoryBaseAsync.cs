using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories.Interfaces
{
    //public interface IRepositoryBaseAsync<TEntity> where TEntity : class
    public interface IRepositoryBaseAsync
    {
        Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class;
        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        // TODO: Rename to FindAsync
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class;
        //Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters);
        Task<int> InsertAsync<TEntity>(TEntity entity);
        Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class;
        Task<int> DeleteByIdAsync<TEntity>(int id) where TEntity : class;
    }
}
