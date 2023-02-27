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
	public class ExpenseController : ControllerBase
	{
		private readonly IExpenseRepository expenseRepository;

		public ExpenseController(IExpenseRepository repo)
		{
			this.expenseRepository = repo;
		}

		// GET: api/<BudgetController>
		[HttpGet]
		public IEnumerable<string> Get(int pageNumber, int pageSize)
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/expense/5
		[HttpGet("{id}")]
		public async Task<Expense> Get(int id)
		{
			var entity = await expenseRepository.GetByIdAsync<Expense>(id);
			return entity;
		}

		// POST api/expense
		// Body: entity
		[HttpPost]
		public async Task<ActionResult<HttpStatusCode>> Post([FromBody] Expense entity)
		{
			if (entity == null)
				return BadRequest();

			int count = await expenseRepository.InsertAsync(entity);

			return Ok();
		}

		// PUT api/expense/
		[HttpPut]
		public async Task<ActionResult<HttpStatusCode>> Put([FromBody] Expense entity)
		{
			if (entity == null)
				return BadRequest();

			int count = await expenseRepository.UpdateAsync(entity);

			return Ok();
		}

		// DELETE api/expense/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<HttpStatusCode>> Delete(int id)
		{
			int count = await expenseRepository.DeleteByIdAsync<Expense>(id);
			return Ok();
		}
	}
}
