using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreShopReportsTask.Models
{
    [Table("supermarket_locations")]
    public class SupermarketLocation
    {
        [Key]
        [Column("supermarket_location_id")]
        public int Id { get; set; }

        [ForeignKey("Supermarket")]
        [Column("supermarket_id")]
        public int SupermarketId { get; set; }

        [ForeignKey("Location")]
        [Column("location_id")]
        public int LocationId { get; set; }

        public Supermarket Supermarket { get; set; } = null!;

        public Location Location { get; set; } = null!;

        public virtual IList<Order> Orders { get; set; } = null!;
    }
}
