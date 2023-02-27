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
public class DebtController : ControllerBase
{
	private readonly IDebtRepository repo;

	public DebtController(IDebtRepository repo)
	{
		this.repo = repo;
	}

	// GET: api/<DebtController>
	[HttpGet]
	public IEnumerable<string> Get(int pageNumber, int pageSize)
	{
		return new string[] { "value1", "value2" };
	}

	// GET api/<DebtController>/5
	[HttpGet("{id}")]
	public async Task<Debt> Get(int id)
	{
		var entity = await repo.Get(id);
		return entity;
	}

	// POST api/<DebtController>
	[HttpPost]
	public async Task<ActionResult<HttpStatusCode>> Post([FromBody] Debt entity)
	{
		if (entity == null)
			return BadRequest();

		var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

		return result.StatusCode;
	}

	// PUT api/<DebtController>/5
	[HttpPut("{id}")]
	public async Task<ActionResult<HttpStatusCode>> Put([FromBody] Debt entity)
	{
		if (entity == null)
			return BadRequest();

		var result = await repo.Save(entity); // Maybe repo.Get(id); updated expense with related items

		return result.StatusCode;
	}

	// DELETE api/<DebtController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		repo.DeleteByIdAsync<Debt>(id);
	}
}
