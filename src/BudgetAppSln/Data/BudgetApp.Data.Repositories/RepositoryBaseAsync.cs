using BudgetApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories
{
    // https://codewithshadman.com/repository-pattern-csharp
    // https://blog.zhaytam.com/2019/03/14/generic-repository-pattern-csharp/
    // https://pradeeploganathan.com/architecture/repository-and-unit-of-work-pattern-asp-net-core-3-1/
    // https://www.freecodespot.com/blog/dotnet-core-repository-pattern/
    //public class RepositoryBaseAsync<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    public abstract class RepositoryBaseAsync<TDbContext> : IRepositoryBaseAsync where TDbContext : DbContext
    {
		internal readonly TDbContext context;

		public RepositoryBaseAsync(TDbContext context)
		{
            this.context = context;
		}

        public virtual async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
            => await context.Set<TEntity>().FindAsync(id);

        public virtual async Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
            => await context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        //public Task<IEnumerable<TEntity>> GetWithRawSql(string query, params object[] parameters)
        //{
        //    //
        //}

        public async Task<int> InsertAsync<TEntity>(TEntity entity)
        {
            context.Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            context.Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync<TEntity>(int id) where TEntity : class
        {
            TEntity entity = await context.Set<TEntity>().FindAsync(id);
            context.Remove(entity);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity ShallowCopy<TEntity>(TEntity entity)
        {
            // https://codereview.stackexchange.com/questions/125149/cloning-entity-framework-entities
            return (TEntity)context.Entry(entity).CurrentValues.ToObject();
        }
    }
}
