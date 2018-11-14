using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMCupCake.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Display(Name="SKU")]
        public string Sku { get; set; }
        [Required]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Range(0, 99999999999999.9999, ErrorMessage = "Your price is not accepted")]
        [Column("Price", TypeName = "DECIMAL(18,4")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
