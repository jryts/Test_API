using Microsoft.EntityFrameworkCore;
using System.Net;
using Test.Api.Domain.Entities;

namespace Test.Api.Data
{
	public class TestDbContext : DbContext
	{
		public TestDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Pizza> Pizzas { get; set; } = null!;
		public DbSet<Pizza_Type> Pizza_Types { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<Order_Detail> Order_Details { get; set; } = null!;


	}
}
