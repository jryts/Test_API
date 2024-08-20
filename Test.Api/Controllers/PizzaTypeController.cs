using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Domain.Entities;

namespace Test.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PizzaTypeController : ControllerBase
	{
		private readonly TestDbContext _testDbContext;

		public PizzaTypeController(TestDbContext testDbContext) => _testDbContext = testDbContext;


		[HttpGet]
		public ActionResult<IEnumerable<Pizza_Type>> Get()
		{
			return _testDbContext.Pizza_Types;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Pizza_Type?>> GetById(string id)
		{
			return await _testDbContext.Pizza_Types.Where(x => x.Id == id).SingleOrDefaultAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Pizza_Type pizza_type)
		{
			await _testDbContext.Pizza_Types.AddAsync(pizza_type);
			await _testDbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = pizza_type.Id }, pizza_type);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Pizza_Type pizza_type)
		{
			_testDbContext.Update(pizza_type);
			await _testDbContext.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var PizzaTypeByIdResult = await GetById(id);
			if (PizzaTypeByIdResult.Value is null)
				return NotFound();

			_testDbContext.Remove(PizzaTypeByIdResult.Value);
			await _testDbContext.SaveChangesAsync();
			return Ok();

		}
	}
}
