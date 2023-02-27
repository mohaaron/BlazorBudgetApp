using BudgetApp.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories.Interfaces
{
	public interface IBudgetRepository : IRepositoryBaseAsync
	{
		Task<Budget> GetGraphAsync(int id);
		Task<DbTaskResult> Save(Budget budget);
	}
}
