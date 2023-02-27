using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data.Repositories;
using BudgetApp.Data.Repositories.Interfaces;
using BudgetApp.Data;
using System.Text.Json.Serialization;
using System.IO.Compression;

namespace BudgetApp.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			string fileName = @"\expenses.db";
			string dbFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + fileName;
			services.AddDbContextFactory<BudgetContext>(options => 
				options
					.UseSqlite("Data Source=" + dbFilePath, x => x.MigrationsAssembly("BudgetApp.Data"))
					.EnableSensitiveDataLogging()
			);

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddTransient<IBudgetRepository, BudgetRepository>();
			services.AddTransient<IExpenseRepository, ExpenseRepository>();
			services.AddTransient<IIncomeRepository, IncomeRepository>();
			services.AddTransient<IDebtRepository, DebtRepository>();

			services.AddControllersWithViews().AddJsonOptions(options => {
				options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
				options.JsonSerializerOptions.PropertyNamingPolicy = null; // prevent camel case
			});
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();
            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
