using BudgetApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories.Interfaces
{
	public interface IDebtRepository : IRepositoryBaseAsync
	{
		Task<Debt> Get(int id);
		Task<DbTaskResult> Save(Debt entity);
	}
}
