using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Api.Domain.Entities
{
    [Table("order_details")]
    public class Order_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_details_id")]
        public int Id { get; set; }

        [Column("order_id")]
        public string Order_Id { get; set; } = null!;

		[Column("pizza_id")]
        public string Pizza_Id { get; set; } = null!;

		[Column("quantity")]
        public int Qty { get; set; }

    }
}
