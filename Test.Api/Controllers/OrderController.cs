using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Domain.Entities;

namespace Test.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private TestDbContext _testDbContext;

		public OrderController(TestDbContext testDbContext) => _testDbContext = testDbContext;

		[HttpGet]
		public ActionResult<IEnumerable<Order>> Get() 
		{ 
			return _testDbContext.Orders.AsNoTracking().ToList();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Order?>> GetById(int id) 
		{ 
			return await _testDbContext.Orders.Where(x=> x.Id == id).SingleOrDefaultAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Order order)
		{
			await _testDbContext.Orders.AddAsync(order);
			await _testDbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new {id = order.Id }, order);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Order order)
		{
			_testDbContext.Update(order);
			await _testDbContext.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var orderByIdResult = await GetById(id);
			if(orderByIdResult.Value is null) 
				return NotFound();
			
			_testDbContext.Remove(orderByIdResult.Value);
			await _testDbContext.SaveChangesAsync();
			return Ok();

		}

	}
}


