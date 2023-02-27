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
	public class ExpenseRepository : RepositoryBaseAsync<BudgetContext>, IExpenseRepository
	{
		public ExpenseRepository(BudgetContext context) : base(context)
		{
			//
		}

		//public async Task<DbTaskResult> Save(Expense entity)
		//{
		//	var result = new DbTaskResult();

		//	context.Update(entity);
		//	try
		//	{
		//		int count = await context.SaveChangesAsync();
		//		if (count > 0)
		//			result.StatusCode = HttpStatusCode.OK;
		//		result.StatusCode = HttpStatusCode.NotModified;
		//	}
		//	catch(Exception x)
		//	{
		//		result.StatusCode = HttpStatusCode.InternalServerError;
		//		result.Message = x.Message;
		//	}

		//	return result;
		//}
	}
}
