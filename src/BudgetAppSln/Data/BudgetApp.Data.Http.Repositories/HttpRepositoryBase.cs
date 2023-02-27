using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetApp.Data.Http.Repositories
{
	public abstract class HttpRepositoryBase//<Tentity> where Tentity : class
	{
		internal readonly HttpClient httpClient;
		internal readonly JsonSerializerOptions serializerOptions;

		public HttpRepositoryBase(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			this.serializerOptions = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve };
		}
	}
}
