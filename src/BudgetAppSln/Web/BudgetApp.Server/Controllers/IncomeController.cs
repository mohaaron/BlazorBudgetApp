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

namespace BudgetApp.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IncomeController : ControllerBase
{
	private readonly IIncomeRepository repo;

	public IncomeController(IIncomeRepository repo)
	{
		this.repo = repo;
	}

	// GET: api/<IncomeController>
	[HttpGet]
	public IEnumerable<string> Get(int pageNumber, int pageSize)
	{
		return new string[] { "value1", "value2" };
	}

	// GET api/<IncomeController>/5
	[HttpGet("{id}")]
	public async Task<Income> Get(int id)
	{
		var entity = await repo.Get(id);
		return entity;
	}

	// POST api/<IncomeController>
	[HttpPost]
	public async Task<ActionResult<HttpStatusCode>> Post([FromBody] Income entity)
	{
		if (entity == null)
			return BadRequest();

		var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

		return result.StatusCode;
	}

	// PUT api/<IncomeController>/5
	[HttpPut]
	public async Task<ActionResult<HttpStatusCode>> Put([FromBody] Income entity)
	{
		if (entity == null)
			return BadRequest();

		var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

		return result.StatusCode;
	}

	// DELETE api/<IncomeController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		repo.DeleteByIdAsync<Income>(id);
	}
}
