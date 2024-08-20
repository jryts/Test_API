using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Api.Domain.Entities
{
	[Table("pizza_types")]
	public record Pizza_Type
	{
		[Key]
		[Column("pizza_type_id")]
		public string Id { get; set; } = null!;

		[Column("name")]
		public string Name { get; set; } = null!;

		[Column("category")]
		public string Category { get; set; } = null!;

		[Column("ingredients")]
		public string Ingredients { get; set; } = null!;
	}
}
