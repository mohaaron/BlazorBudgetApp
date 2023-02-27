using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Data.Http.Repositories
{
	public class HttpBudgetRepository : HttpRepositoryBase, IHttpClientRepository<Budget>
	{
		private bool disposedValue;

		public HttpBudgetRepository(HttpClient httpClient) : base(httpClient)
		{
			//
		}

		public async Task<DbTaskResult> Create(Budget entity)
		{
			HttpResponseMessage resp = await httpClient.PostAsJsonAsync<Budget>("api/Budget", entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<DbTaskResult> Delete(int id)
		{
			HttpResponseMessage resp = await httpClient.DeleteAsync("api/Budget" + id);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<Budget> Get(int id)
		{
			Budget entity = null;
			try
			{
				entity = await httpClient.GetFromJsonAsync<Budget>("api/Budget/" + id, this.serializerOptions);
			}
			catch(Exception x)
			{
				x.ToString();
			}
			return entity;
		}

		public async Task<DbTaskResult> Update(Budget entity)
		{
			HttpResponseMessage resp = await httpClient.PutAsJsonAsync<Budget>("api/Budget", entity, this.serializerOptions);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				disposedValue = true;
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~HttpBudgetRepository()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
