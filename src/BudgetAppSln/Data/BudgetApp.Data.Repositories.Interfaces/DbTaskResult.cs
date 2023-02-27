using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Data.Repositories.Interfaces
{
	public class DbTaskResult
	{
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}
