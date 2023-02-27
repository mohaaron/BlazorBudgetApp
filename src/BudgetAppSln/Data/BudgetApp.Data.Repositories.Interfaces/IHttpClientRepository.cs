using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories.Interfaces
{
	public interface IHttpClientRepository<T> : IDisposable
	{
		//Task<List<T>> GetPaged(int page, int pageSize);
		Task<T> Get(int id);
		Task<DbTaskResult> Create(T entity);
		Task<DbTaskResult> Update(T entity);
		Task<DbTaskResult> Update(T entity, JsonSerializerOptions jsonOptions);
		Task<DbTaskResult> Delete(int id);
	}
}
