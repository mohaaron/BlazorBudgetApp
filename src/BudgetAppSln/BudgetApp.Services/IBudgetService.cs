using BudgetApp.Data.Models;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
	public interface IBudgetService
	{
		Task<Budget> Get(int id);
	}
}
