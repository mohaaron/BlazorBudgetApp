using BlazorApp.Data.Models;
using BlazorApp.Data.Repositories.Interfaces;
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

namespace BlazorApp.Data.Http.Repositories
{
	public class HttpDebtRepository : HttpRepositoryBase, IHttpClientRepository<Debt>
	{
		private bool disposedValue;

		public HttpDebtRepository(HttpClient httpClient) : base(httpClient)
		{
			//
		}

		public async Task<DbTaskResult> Create(Debt entity)
		{
			HttpResponseMessage resp = await httpClient.PostAsJsonAsync<Debt>("api/Debt", entity, this.serializerOptions);

			//if (resp.IsSuccessStatusCode)
			//	return entity;

			//return null;
			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<DbTaskResult> Delete(int id)
		{
			HttpResponseMessage resp = await httpClient.DeleteAsync("api/Debt" + id);

			return new DbTaskResult
			{
				StatusCode = resp.StatusCode
			};
		}

		public async Task<Debt> Get(int id)
		{
			Debt entity = null;
			try
			{
				entity = await httpClient.GetFromJsonAsync<Debt>("api/Debt/" + id, this.serializerOptions);
			}
			catch (Exception x)
			{
				x.ToString();
			}
			return entity;
		}

		public async Task<DbTaskResult> Update(Debt entity)
		{
			HttpResponseMessage resp = await httpClient.PutAsJsonAsync<Debt>("api/Debt", entity, this.serializerOptions);

			//if (resp.IsSuccessStatusCode)
			//	return entity;

			//return null;
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
		// ~HttpDebtRepository()
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
