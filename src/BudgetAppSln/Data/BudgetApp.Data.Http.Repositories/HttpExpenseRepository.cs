using BudgetApp.Data.Models;
using BudgetApp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetApp.Data.Http.Repositories
{
	public class HttpExpenseRepository : HttpRepositoryBase
	{
		public HttpExpenseRepository(HttpClient httpClient) : base(httpClient)
		{
			//
		}

		public async Task<Expense> Get(int id)
		{
			Expense entity = null;
			try
			{
				entity = await httpClient.GetFromJsonAsync<Expense>("api/Expense/" + id, this.serializerOptions);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return entity;
		}

		public async Task<DbTaskResult> Save(Expense entity)
		{
			HttpResponseMessage resp;
			if (entity.Id == 0)
				resp = await httpClient.PostAsJsonAsync<Expense>("api/Expense", entity, this.serializerOptions);
			else
				resp = await httpClient.PutAsJsonAsync<Expense>("api/Expense", entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
