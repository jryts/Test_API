using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Api.Domain.Entities
{
    [Table("orders")]
    public record Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Order_Date { get; set; }

        [Column("time")]
        public string Order_Time { get; set; } = null!;

    }
}
