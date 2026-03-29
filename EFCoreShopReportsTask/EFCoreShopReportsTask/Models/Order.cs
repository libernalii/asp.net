using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreShopReportsTask.Models
{
    [Table("customer_orders")]
    public class Order
    {
        [Key]
        [Column("customer_order_id")]
        public int Id { get; set; }

        [Column("operation_time")]
        public string OperationTime { get; set; }

        [Column("supermarket_location_id")]
        [ForeignKey("SupermarketLocation")]
        public int SupermarketLocationId { get; set; }

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public SupermarketLocation SupermarketLocation { get; set; } = null!;

        public Customer? Customer { get; set; } = null!;

        public virtual IList<OrderDetail> Details { get; set; } = null!;
    }
}
