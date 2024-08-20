using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Domain.Entities;

namespace Test.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailController : ControllerBase
	{
		private readonly TestDbContext _testDbContext;

		public OrderDetailController(TestDbContext testDbContext) => _testDbContext = testDbContext;


		[HttpGet]
		public ActionResult<IEnumerable<Order_Detail>> Get()
		{
			return _testDbContext.Order_Details;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Order_Detail?>> GetById(int id)
		{
			return await _testDbContext.Order_Details.Where(x => x.Id == id).SingleOrDefaultAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Order_Detail order_detail)
		{
			await _testDbContext.Order_Details.AddAsync(order_detail);
			await _testDbContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetById), new { id = order_detail.Id }, order_detail);
		}

		[HttpPut]
		public async Task<ActionResult> Update(Order_Detail order_detail)
		{
			_testDbContext.Update(order_detail);
			await _testDbContext.SaveChangesAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var orderDetailByIdResult = await GetById(id);
			if (orderDetailByIdResult.Value is null)
				return NotFound();

			_testDbContext.Remove(orderDetailByIdResult.Value);
			await _testDbContext.SaveChangesAsync();
			return Ok();

		}

	}
}
