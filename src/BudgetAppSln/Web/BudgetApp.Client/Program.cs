//global using BudgetApp.Client.Shared.FluxStore;

using BudgetApp.Data.Http.Repositories;
using BudgetApp.Data.Models;
using BudgetApp.Data.Repositories.Interfaces;
using Blazored.Modal;
using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Client.Shared.FluxStore;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BudgetApp.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

            string baseAddress = builder.HostEnvironment.BaseAddress;
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
			builder.Services.AddScoped<IHttpClientRepository<Budget>>(r => new HttpClientRepository<Budget>(baseAddress, "api/budget"));
			builder.Services.AddScoped<IHttpClientRepository<Expense>>(r => new HttpClientRepository<Expense>(baseAddress, "api/expense"));
			builder.Services.AddScoped<IHttpClientRepository<Income>>(r => new HttpClientRepository<Income>(baseAddress, "api/income"));
			builder.Services.AddScoped<IHttpClientRepository<Debt>>(r => new HttpClientRepository<Debt>(baseAddress, "api/debt"));

            // How can we use this approach to send MediatR requests
            // Maybe also try using a single QueryApi class that injects HttpClient where endpoints can be set
            //services.AddHttpClient<ICatalogService, CatalogService>(client =>
            //{
            //    client.BaseAddress = new Uri("/odata/Catalogs");
            //});
            //services.AddHttpClient<IBasketService, BasketService>(client =>
            //{
            //    client.BaseAddress = new Uri("/odata/Baskets");
            //});
            //services.AddHttpClient<IOrderingService, OrderingService>(client =>
            //{
            //    client.BaseAddress = new Uri("/odata/Orders");
            //});

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(Program).Assembly, assemblies);
                options.AddMiddleware<ProfilingMiddleware>();
#if DEBUG
                options.UseReduxDevTools(rdt =>
                {
                    rdt.Name = "Budget App";
                });
#endif
            });

            builder.Services.AddHotKeys2();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
		}
	}
}
