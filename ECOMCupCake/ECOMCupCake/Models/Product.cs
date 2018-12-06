using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOMCupCake.Models
{
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }


        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        /// <value>
        /// The SKU.
        /// </value>
        [Display(Name="SKU")]
        public string Sku { get; set; }
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// The product name.
        /// </value>
        [Required]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Range(0, 99999999999999.9999, ErrorMessage = "Your price is not accepted")]
        [Column("Price", TypeName = "DECIMAL(18,4)")]
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }
        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        /// <value>
        /// The published.
        /// </value>
        public bool Published { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets the slug.
        /// </summary>
        /// <value>
        /// The slug.
        /// </value>
        [NotMapped]
        public string Slug { get => Name.ToLower().Replace(" ", "-"); }
    }
}
