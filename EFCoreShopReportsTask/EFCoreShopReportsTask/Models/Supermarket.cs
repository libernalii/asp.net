using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreShopReportsTask.Models
{
    [Table("supermarkets")]
    public class Supermarket
    {
        [Key]
        [Column("supermarket_id")]
        public int Id { get; set; }

        [Column("supermarket_name")]
        public string Name { get; set; }

        public virtual IList<SupermarketLocation> Locations { get; set; } = null!;
    }
}
