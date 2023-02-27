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
	public class IncomeRepository : RepositoryBaseAsync<BudgetContext>, IIncomeRepository
	{
		public IncomeRepository(BudgetContext context) : base(context)
		{
			//
		}

		public async Task<Income> Get(int id)
		{
			try
			{
				return await this.GetByIdAsync<Income>(id);
			}
			catch(Exception x)
			{
				x.ToString();
			}

			return null;
		}

		public async Task<DbTaskResult> Save(Income entity)
		{
			var result = new DbTaskResult();
			await Task.CompletedTask;

			context.Update(entity);
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
