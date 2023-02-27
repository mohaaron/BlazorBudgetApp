using BudgetApp.Data.Models;
using BudgetApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories
{
	public class BudgetRepository : RepositoryBaseAsync<BudgetContext>, IBudgetRepository
	{
		public BudgetRepository(BudgetContext context) : base(context)
		{
			//
		}

		public async Task<Budget> GetGraphAsync(int id)
		{
			return await context.Budget
			.Include(e => e.Expenses)
			.Include(i => i.Incomes)
				.ThenInclude(i => i.Expenses) // Expenses grouped by paycheck
			.SingleAsync(b => b.Id == id);
		}

		public async Task<DbTaskResult> Save(Budget budget)
		{
			var result = new DbTaskResult();
			await Task.CompletedTask;

			context.Update(budget);
			try
			{
				await context.SaveChangesAsync();
				result.StatusCode = HttpStatusCode.OK;
			}
			catch(Exception x)
			{
				result.StatusCode = HttpStatusCode.InternalServerError;
				result.Message = x.Message;
			}

			return result;
		}
	}
}
