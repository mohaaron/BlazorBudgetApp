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
	public class HttpIncomeRepository : HttpRepositoryBase
	{
		public HttpIncomeRepository(HttpClient httpClient) : base(httpClient)
		{
			//
		}

		public async Task<Income> Get(int id)
		{
			Income entity = null;
			try
			{
				entity = await httpClient.GetFromJsonAsync<Income>("api/income/" + id, this.serializerOptions);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return entity;
		}

		public async Task<DbTaskResult> Save(Income entity)
		{
			HttpResponseMessage resp;
			if (entity.Id == 0)
				resp = await httpClient.PostAsJsonAsync<Income>("api/income", entity, this.serializerOptions);
			else
				resp = await httpClient.PutAsJsonAsync<Income>("api/income", entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}
	}
}
