using BudgetApp.Data.Models;
using BudgetApp.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BudgetController : ControllerBase
	{
		private readonly IBudgetRepository repo;

		public BudgetController(IBudgetRepository repo)
		{
			this.repo = repo;
		}

		// GET: api/<BudgetController>
		[HttpGet]
		public IEnumerable<string> Get(int pageNumber, int pageSize)
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<BudgetController>/5
		[HttpGet("{id}")]
		public async Task<Budget> Get(int id)
		{
			Budget entity = await repo.GetGraphAsync(id);
			return entity;
		}

		// POST api/<BudgetController>
		[HttpPost]
		public async Task<ActionResult<HttpStatusCode>> Post([FromBody] Budget entity)
		{
			if (entity == null)
				return BadRequest();

			var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

			return result.StatusCode;
		}

		// PUT api/<BudgetController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<Budget>> Put([FromBody] Budget entity)
		{
			if (entity == null)
				return BadRequest();

			await repo.Save(entity);

			return Ok(entity);
		}

		// DELETE api/<BudgetController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			repo.DeleteByIdAsync<Budget>(id);
		}
	}
}
