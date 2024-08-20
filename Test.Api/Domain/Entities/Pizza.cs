using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Api.Domain.Entities
{
    [Table("pizzas")]
    public record Pizza
    {
        [Key]
        [Column("pizza_id")]
        public string Id { get; set; } = null!;

		[Column("pizza_type_id")]
        public string Type_Id { get; set; } = null!;

		[Column("size")]
        public string Size { get; set; } = null!;

		[Column("price", TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
    }
}
