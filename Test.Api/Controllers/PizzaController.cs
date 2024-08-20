using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Domain.Entities;

namespace Test.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaController : ControllerBase
	{
		private readonly TestDbContext _testDbContext;

		public PizzaController(TestDbContext testDbContext) => _testDbContext = testDbContext;


		[HttpGet]
		public ActionResult<IEnumerable<Pizza>> Get()
		{
			return _testDbContext.Pizzas;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Pizza?>> GetById(string id)
		{
			return await _testDbContext.Pizzas.Where(x => x.Id == id).SingleOrDefaultAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Pizza pizza)
		{
			await _testDbContext.Pizzas.AddAsync(pizza);
			await _testDbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Pizza pizza)
		{
			_testDbContext.Update(pizza);
			await _testDbContext.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var PizzaByIdResult = await GetById(id);
			if (PizzaByIdResult.Value is null)
				return NotFound();

			_testDbContext.Remove(PizzaByIdResult.Value);
			await _testDbContext.SaveChangesAsync();
			return Ok();

		}

	}
}
