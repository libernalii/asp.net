using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreShopReportsTask.Models
{
    [Table("product_manufacturers")]
    public class Manufacturer
    {
        [Key]
        [Column("manufacturer_id")]
        public int Id { get; set; }

        [Column("manufacturer_name")]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; } = null!;
    }
}
